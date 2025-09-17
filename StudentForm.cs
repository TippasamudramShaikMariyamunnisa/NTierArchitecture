using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using NTierDemoApp.BO;
using NTierDemoApp.DAO;
using NTierDemoApp.Model;


namespace NTierDemoApp
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            dgStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgStudent.AutoGenerateColumns = false;
            dgStudent.AllowUserToAddRows = false;
            dgStudent.AllowUserToDeleteRows = false;
            dgStudent.ReadOnly = true;
            dgStudent.MultiSelect = false;

            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            StudentBOManager manager = new StudentBOManager();
            dgStudent.DataSource = manager.GetAllStudents().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                string rawMarks = textBox2.Text.Trim();
                MessageBox.Show("Raw Marks Input: '" + rawMarks + "'");

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter the student's name.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(rawMarks) || !int.TryParse(rawMarks, out int marks))
                {
                    MessageBox.Show("Please enter valid numeric marks.");
                    return;
                }

                StudentBO student = new StudentBO
                {
                    StuName = textBox1.Text.Trim(),
                    Marks = marks,
                    DateOfBirth = dateTimePicker1.Value,
                    IsActive = checkBox1.Checked
                };

                try
                {
                    student.Validate();
                    StudentBOManager manager = new StudentBOManager();
                    manager.InsertStudent(student);
                    MessageBox.Show("Student added successfully.");
                    BindDataToGrid();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show("Validation Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgStudent.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a student to modify.");
                    return;
                }

                string rawMarks = textBox2.Text.Trim();
                MessageBox.Show("Raw Marks Input: '" + rawMarks + "'");

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter the student's name.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(rawMarks) || !int.TryParse(rawMarks, out int marks))
                {
                    MessageBox.Show("Please enter valid numeric marks.");
                    return;
                }

                int id = Convert.ToInt32(dgStudent.SelectedRows[0].Cells["PKStudentId"].Value);

                StudentBO student = new StudentBO
                {
                    PKStudentId = id,
                    StuName = textBox1.Text.Trim(),
                    Marks = marks,
                    DateOfBirth = dateTimePicker1.Value,
                    IsActive = checkBox1.Checked
                };

                try
                {
                    student.Validate();
                    StudentBOManager manager = new StudentBOManager();
                    manager.UpdateStudent(student);
                    MessageBox.Show("Student updated successfully.");
                    BindDataToGrid();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show("Validation Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgStudent.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a student to delete.");
                    return;
                }

                int id = Convert.ToInt32(dgStudent.SelectedRows[0].Cells["PKStudentId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    StudentBOManager manager = new StudentBOManager();
                    manager.DeleteStudent(id);
                    MessageBox.Show("Student deleted successfully.");
                    BindDataToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell click if needed
        }
    }
}
