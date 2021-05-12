using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AssignmentInternship
{
    public partial class Form1 : Form
    {
        // mảng chứa danh sách nguyện vọng của sinh viên
        List<Student> listStudent = new List<Student>();

        // danh sách công ty và số lượng tuyển dụng
        List<Company> listCompany = new List<Company>();
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// khi btn chọn file danh sách sinh viên click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Chọn file danh sách sinh viên";
            fdlg.Filter = "excel file | *.xls; *.xlsx";
            fdlg.FilterIndex = 1;
            fdlg.Multiselect = false;
            fdlg.RestoreDirectory = true;

            // nếu chọn file thành công
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileSV.Text = fdlg.FileName;
                using (XLWorkbook workbook = new XLWorkbook(fdlg.FileName))
                {
                    bool isFirstRow = true;
                    var rows = workbook.Worksheet(1).RowsUsed();
                    foreach (var row in rows)
                    {
                        // header file excel: stt, mssv, họ và tên, GPA, nguyện vọng
                        if (isFirstRow)
                        {
                            isFirstRow = false;
                        }
                        else
                        {
                            int i = 0;
                            Student item = new Student();
                            item.listWish = new string[0];
                            foreach (IXLCell cell in row.Cells())
                            {
                                // cột mã số sinh viên
                                if (i == 1)
                                {
                                    item.Code = cell.Value.ToString();
                                }

                                // cột họ và tên
                                if (i == 2)
                                {
                                    item.Name = cell.Value.ToString();
                                }

                                // cột GPA
                                if (i == 3)
                                {
                                    item.GPA = (double)cell.Value;
                                }

                                // nếu là cột nguyện vọng
                                if (i == 4)
                                {
                                    string data = cell.Value.ToString();
                                    // mảng danh sách công ty mong muốn thực tập theo thứ tự ưu tiên từ đầu đến cuối
                                    var listWish = data.Split(",");
                                    item.listWish = listWish;
                                }

                                i++;
                            }

                            listStudent.Add(item);
                        }
                    }

                    //dataGrid.DataSource = dt.DefaultView;
                    //Cursor.Current = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// khi btn chọn danh sách công ty click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileCom_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Chọn file danh sách công ty";
            fdlg.Filter = "excel file | *.xls; *.xlsx";
            fdlg.FilterIndex = 1;
            fdlg.Multiselect = false;
            fdlg.RestoreDirectory = true;

            // nếu chọn file thành công
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileCom.Text = fdlg.FileName;
                using (XLWorkbook workbook = new XLWorkbook(fdlg.FileName))
                {
                    bool isFirstRow = true;
                    var rows = workbook.Worksheet(1).RowsUsed();
                    foreach (var row in rows)
                    {
                        // header của file: stt, mã công ty, tên công ty, số lượng tuyển dụng
                        if (isFirstRow)
                        {
                            isFirstRow = false;
                        }
                        else
                        {
                            int i = 0;
                            Company com = new Company();
                            foreach (IXLCell cell in row.Cells())
                            {
                                // cột mã công ty
                                if (i == 1)
                                {
                                    com.Code = cell.Value.ToString();
                                }

                                // cột tên công ty
                                if (i == 2)
                                {
                                    com.Name = cell.Value.ToString();
                                }

                                // cột số lượng tuyển dụng
                                if (i == 3)
                                {
                                    com.Quantity = (double)cell.Value;
                                }

                                i++;
                            }

                            // thêm công ty vào danh sách
                            listCompany.Add(com);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// thực hiện ghép nối khi nhấn click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // số lượng sinh viên
            int cSt = listStudent.Count;

            // số lượng công ty
            int cCo = listCompany.Count;

            // danh sách sinh viên đã match theo công ty
            // mục đích là để so sánh khi có nhiều hơn số lượng sinh viên
            // nộp vào công ty so với số lượng tuyển dụng của công ty đó
            Dictionary<string, List<Student>> listMatched = new Dictionary<string, List<Student>>();

            // list lưu lại công ty mà sinh vien đã nộp đơn.
            Dictionary<string, bool[]> listSeen = new Dictionary<string, bool[]>();

            // gán list match sinh viên ban đầu là rỗng
            for (int i=0; i<cCo; i++)
            {
                // khởi tạo danh sách sinh viên rỗng
                List<Student> listSt = new List<Student>();

                listMatched.Add(listCompany[i].Code, listSt);

            }

            // khởi tạo danh sách sinh vên đã nộp đơn là chưa nộp vào công ty nào
            for (int j=0; j<cSt; j++)
            {
                bool[] seen = new bool[listStudent[j].listWish.Length];
                listSeen.Add(listStudent[j].Code, seen);
            }

            // biến check xem đã duyệt hết nguyện vọng của sinh viên chưa
            bool check = false;

            // thực hiện match sinh viên
            do
            {
                // tìm sinh viên chưa được ghép
                Student st = new Student();
                for (int i = 0; i < listStudent.Count; i++)
                {
                    // nếu sinh viên chưa match vào công ty nào và chưa duyệt hết danh sách nguyện vọng
                    if (listStudent[i].CompanyCodeMatched == null && !listStudent[i].ThroughAll)
                    {
                        st = listStudent[i];
                        break;
                    }
                }

                // nếu như không tìm được sinh viên nào free nữa
                if (st.Code == null)
                {
                    break;
                }

                // nếu sinh viên có danh sách nguyện vọng
                if (st.listWish.Length == 0)
                {
                    st.ThroughAll = true;
                    continue;
                }

                Company cp = new Company();
                // lấy ra công ty nằm trong nguyện vọng của sinh viên và sinh viên chưa nộp đơn
                for (int i=0; i< listSeen[st.Code].Length; i++)
                {
                    // nếu đã trải qua hết các công ty
                    if (i == listSeen[st.Code].Length - 1)
                    {
                        st.ThroughAll = true;
                    }

                    if (!listSeen[st.Code][i])
                    {
                       foreach(var item in listCompany)
                        {
                            if (item.Code.ToLower() == (st.listWish[i].Trim()).ToLower())
                            {
                                cp = item;
                            }
                        }

                       // đánh dấu là đã nộp đơn
                        listSeen[st.Code][i] = true;
                        break;
                    }
                }

                // nếu công ty đó vẫn chưa tuyển đủ người
                if (listMatched[cp.Code].Count < cp.Quantity)
                {
                    // thêm sinh viên vào danh sách tuyển dụng
                    listMatched[cp.Code].Add(st);

                    // match công ty với sinh viên
                    st.CompanyCodeMatched = cp.Code;
                }
                else
                {
                    // thêm sinh viên này vào danh sách để so sánh
                    listMatched[cp.Code].Add(st);
                    // match công ty với sinh viên
                    st.CompanyCodeMatched = cp.Code;

                    // sắp xếp danh sách sinh viên
                    listMatched[cp.Code].Sort(delegate (Student x, Student y) {
                        return y.GPA.CompareTo(x.GPA);
                    });

                    // lấy ra sinh viên cuối cùng
                    Student lastStudent = listMatched[cp.Code][listMatched[cp.Code].Count - 1];
                    // xóa sinh viên đó khỏi danh sách
                    listMatched[cp.Code].RemoveAt(listMatched[cp.Code].Count - 1);

                    // bỏ match của sinh viên đó ra để đi match với công ty khác
                    lastStudent.CompanyCodeMatched = null;
                }

                check = true;

                // kiểm tra sinh viên đã thăm hết nguyện vọng của mình chưa
                foreach(var item in listStudent)
                {
                    // nếu có sinh viên vẫn chưa duyệt hết
                    if(!item.ThroughAll)
                    {
                        check = false;
                    }
                }

            }
            while (!check);

            // in kết quả ra bảng
            Cursor.Current = Cursors.WaitCursor;
            // danh sách kết quả matching
            DataTable dt = new DataTable();

            dt.Columns.Add("MSSV");
            dt.Columns.Add("Họ và tên");
            dt.Columns.Add("GPA");
            dt.Columns.Add("Công ty thực tập");
            for (int i=0; i<listStudent.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1][0] = listStudent[i].Code;
                dt.Rows[dt.Rows.Count - 1][1] = listStudent[i].Name; 
                dt.Rows[dt.Rows.Count - 1][2] = listStudent[i].GPA;
                dt.Rows[dt.Rows.Count - 1][3] = listStudent[i].CompanyCodeMatched;
            }

            dataGrid.DataSource = dt.DefaultView;
            Cursor.Current = Cursors.Default;

            // danh sách kết quả tuyển dụng của các công ty
            DataTable dtCom = new DataTable();
            dtCom.Columns.Add("Mã Công ty");
            dtCom.Columns.Add("Số Lượng");
            for (int i = 0; i < listMatched.Count; i++)
            {
                dtCom.Rows.Add();
                dtCom.Rows[dtCom.Rows.Count - 1][0] = listCompany[i].Code;
                dtCom.Rows[dtCom.Rows.Count - 1][1] = listMatched[listCompany[i].Code].Count;
            }

            // xuất file excel
            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    workbook.Worksheets.Add(dt, "Danh sách thực tập");
                    workbook.Worksheets.Add(dtCom, "Kết quả tuyển dụng");
                    workbook.SaveAs("Danh sách thực tập.xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file");
            }
        }
    }

    // model sinh viên
    class Student
    {
        // mã số sinh viên
        public string Code { set; get; }
        // tên sinh viên
        public string Name { set; get; }
        // gpa
        public double GPA { set; get; }
        // danh sách công ty mong muốn vào thực tập, xếp theo thứ tự ưu tiên giảm dần.
        public string[] listWish { set; get; }
        // mã công ty đã ghép
        public string CompanyCodeMatched { set; get; }
        // đã nộp hết nguyện vọng vào công ty chưa
        public bool ThroughAll { set; get; }
    }

    // model công ty
    class Company
    {
        // mã công ty
        public string Code { set; get; }
        // tên công ty
        public string Name { set; get; }
        // số lượng tuyển dụng
        public double Quantity { set; get; }
    }
}
