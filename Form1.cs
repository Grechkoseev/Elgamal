namespace Lab_6;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private const int P = 137;
    private const int G = 20;
    private const int X = 3;

    private readonly List<Message> _messageList = new();

    private void signButton_Click(object sender, EventArgs e)
    {
        var generatingPolynomial = new List<int> { 0, 0, 0, 0, 0, 1, 1, 1 };
        var hashFunction = new HashFunctionCrc(generatingPolynomial);
        var elGamalEncryption = new ElGamalEncryption(P, G, X);
        var i = 0;

        explanationLabel.Visible = true;

        if (openFileDialog.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }

        var filename = openFileDialog.FileName;
        selectedFileLabel.Text = string.Concat("Выбран файл  ", openFileDialog.SafeFileName);
        selectedFileLabel.Visible = true;
        var fileBytes = File.ReadAllBytes(filename);

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        { Name = "dgvMessage", HeaderText = "Message", Width = 70 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "dgvHash", HeaderText = "Hash", Width = 70 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "dgvR", HeaderText = "R", Width = 70 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "dgvS", HeaderText = "S", Width = 70 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        { Name = "dgvLeftSideOfEquality", HeaderText = "y^r * r^s mod p", Width = 70 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        { Name = "dgvRightSideOfEquality", HeaderText = "g^h mod p", Width = 70 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        { Name = "dgvIsEqual", HeaderText = "Equality", Width = 70 });

        foreach (var fileByte in fileBytes)
        {
            var hash = hashFunction.GetHash(fileByte);
            elGamalEncryption.CountRS(hash, out var r, out var s);
            _messageList.Add(new Message(fileByte, r, s));

            var row = new DataGridViewRow();
            row.CreateCells(dataGridView);

            row.Cells[0].Value = fileByte;
            row.Cells[1].Value = hash;
            row.Cells[2].Value = r;
            row.Cells[3].Value = s;

            dataGridView.Rows.Add(row);
            dataGridView.Rows[i].HeaderCell.Value = i + " блок";
            i++;
        }
    }

    private void checkButton_Click(object sender, EventArgs e)
    {
        var generatingPolynomial = new List<int> { 0, 0, 0, 0, 0, 1, 1, 1 };
        var hashFunction = new HashFunctionCrc(generatingPolynomial);
        var elGamalEncryption = new ElGamalEncryption(P, G, X);
        var isWrongBlock = false;

        for (var i = 0; i < _messageList.Count; i++)
        {
            dataGridView.Rows[i].Cells[4].Value =
                elGamalEncryption.CountLeftSide(_messageList[i].R, _messageList[i].S);
            dataGridView.Rows[i].Cells[5].Value =
                elGamalEncryption.CountRightSide(hashFunction.GetHash(_messageList[i].M));
            dataGridView.Rows[i].Cells[6].Value = elGamalEncryption.IsLeftAndRightEquals(_messageList[i].R,
                _messageList[i].S, hashFunction.GetHash(_messageList[i].M));
        }

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.Cells[6].Value.ToString() != true.ToString())
            {
                MessageBox.Show((string)row.Cells[0].Value +
                                " имеет различия в подсчете левой и правой части равенства. ЭЦП не совпадает.");
                isWrongBlock = true;
                break;
            }
        }

        if (!isWrongBlock)
        {
            MessageBox.Show("Каждый блок имеет верную ЭЦП, файл содержит верные данные", "Lab_6 10 variant");
        }
    }
}