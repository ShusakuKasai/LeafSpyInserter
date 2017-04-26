using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafSpyInserter
{
    class DatabaseAccessor
    {
        public static int getExperimentId()
        {

            DataTable maxExperimentId = new DataTable();

            String connectionString = "Data Source=ECOLOGDB2016;Initial Catalog=ECOLOGDBver3;Integrated Security=True;Connection Timeout=60";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string query = "SELECT MAX(EXPERIMENT_ID)+1 FROM LEAFSPY_RAW_FULLCHARGELOSS";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(maxExperimentId);
            }
            if(maxExperimentId.Rows[0][0]== null)
            {
                return 1;
            }
            int experimentId = System.Convert.ToInt32(maxExperimentId.Rows[0][0]);
                return experimentId;
        }
    }
}
