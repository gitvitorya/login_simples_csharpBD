using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

        }

        public SQLiteConnection conexao;

        public SQLiteConnection ObterConexao() {
            conexao = new SQLiteConnection("Data Source=C:\\Users\\vitorya.candido\\source\\repos\\ProjetoBD\\database.db");
            conexao.Open();
            return conexao;
        }

        public DataTable Consulta(string SQL) {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var cmd = ObterConexao().CreateCommand();
            cmd.CommandText = SQL;
            da = new SQLiteDataAdapter(cmd.CommandText, ObterConexao());
            da.Fill(dt);
            return dt;


        }

        private void button1_Click(object sender, EventArgs e) {
            string username = textBox1.Text; //vy
            string senha = textBox2.Text; // 1234

            string sql = "SELECT * FROM users WHERE username='"+username+ "' AND senha='" +senha+ "'";

            DataTable dt = Consulta(sql);

            if (dt.Rows.Count > 0) {
                this.Close();
            }
            else {
                MessageBox.Show("Usuário ou senha incorretos");
            }


        }
    }
}
