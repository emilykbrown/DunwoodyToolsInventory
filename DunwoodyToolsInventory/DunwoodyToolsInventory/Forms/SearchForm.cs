using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class SearchForm : Form
{
    public SearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        string searchQuery = txtSearch.Text.Trim();

        using (SqlConnection conn = Database.GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT InventoryID, InventoryName, CategoryName, Status FROM Inventory WHERE InventoryName LIKE @Search OR CategoryName LIKE @Search";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Search", $"%{searchQuery}%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvInventory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
