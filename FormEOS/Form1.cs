using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace FormEOS
{
    public partial class Form1 : Form
    {
        private int countdown = 10; // Giá trị ban đầu của countdown
        private System.Windows.Forms.Timer timer;
        private IKeyboardMouseEvents hookEvents;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CLOSE = 0xF060;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                // Ngăn chặn hành động đóng cửa sổ khi sử dụng phím tắt Windows
                return;
            }

            base.WndProc(ref m);
        }
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            hookEvents = Hook.GlobalEvents();
            hookEvents.KeyDown += HookEvents_KeyDown;


        }

        private void HookEvents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                // Ngăn chặn phím tắt Ctrl + Alt + Delete
            }
            else if (e.Alt && e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                // Ngăn chặn phím tắt Alt + Tab
            }
            else if (e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                // Ngăn chặn phím tắt Windows
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if ((Control.ModifierKeys & Keys.Alt) != 0 && e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true; // Hủy sự kiện đóng form nếu Alt + F4 được nhấn
                }
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo và cấu hình Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Cập nhật countdown mỗi giây
            timer.Tick += Timer_Tick;

            // Khởi động Timer
            timer.Start();
            // set font 
            int fontSize = (int)richTextBox1.Font.Size;

            // Set the numericUpDown1's Value to the font size
            numericUpDown1.Value = fontSize;
            // Gán văn bản mới cho RichTextBox
            richTextBox1.Text = "Đây là văn bản mới.";

            // Hoặc, bạn cũng có thể nối thêm văn bản vào nội dung hiện có
            richTextBox1.Text += "\nThêm văn bản mới.";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Giảm giá trị của countdown
            countdown--;

            // Kiểm tra nếu countdown đạt 0
            if (countdown <= 0)
            {
                // Dừng Timer
                timer.Stop();

                // Thực hiện các hành động khi countdown đạt 0
                lbCountDown.Text = $"00:00";
                MessageBox.Show("Countdown đạt 0!");
                return;
            }

            // Tính toán phút và giây từ giá trị countdown
            int minutes = countdown / 60;
            int seconds = countdown % 60;

            // Hiển thị giá trị countdown trên Label
            lbCountDown.Text = $"{minutes:00}:{seconds:00}";
        }

        private void btnFinish_Click_1(object sender, EventArgs e)
        {
            if (cbFinish.Checked)
            {
                Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị mới từ numericUpDown1
            int fontSize = (int)numericUpDown1.Value;

            // Đặt kích cỡ chữ cho richTextBox1
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, fontSize);
        }

    }

}