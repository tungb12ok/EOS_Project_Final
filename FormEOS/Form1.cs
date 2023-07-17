using System.Windows.Forms;
namespace FormEOS
{
    public partial class Form1 : Form
    {
        private int countdown = 10; // Giá trị ban đầu của countdown
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift || e.KeyCode == Keys.Escape)
            {
                e.Handled = true; // Ngăn chặn xử lý các phím tắt
            }
        }
        private void listView1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, listView1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo và cấu hình Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Cập nhật countdown mỗi giây
            timer.Tick += Timer_Tick;

            // Khởi động Timer
            timer.Start();
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


    }

}