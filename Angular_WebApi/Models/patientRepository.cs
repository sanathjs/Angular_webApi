using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace Angular_WebApi.Models
{
    public class patientRepository
    {

        public List<patient> GetAllPatients()
        {
            SqlConnection con = new SqlConnection("Data Source=DIN35002276;Initial Catalog=Hospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd  = new SqlCommand("select ID, Name, Address, CONVERT(VARCHAR(12), DOB, 106) DOB, Phone, EmergencyContact, CONVERT(VARCHAR(12), DateOfRegistration, 106) DateOfRegistration from [Hospital].[dbo].patient", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            List<patient> pat = new List<patient>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                pat.Add(new patient
                {
                    ID = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    Address = row[2].ToString(),
                    DateOfBirth = row[3].ToString(),
                    Phone = row[4].ToString(),
                    EmergencyContact = row[5].ToString(),
                    DateOfRegistration = row[6].ToString()
                });
            }
            con.Close();

            return pat;

        }

        public List<patient> GetPatient(patient patdetails)
        {
            //Name,Address,DateOfBirth,Phone,EmergencyContact,DateOfRegistration
            SqlConnection con = new SqlConnection("Data Source=DIN35002276;Initial Catalog=Hospital;Integrated Security=True");
            con.Open();
            string sqlQuery;
            sqlQuery = "SELECT * FROM [Hospital].[dbo].[Patient] WHERE 1=1 ";

            if (patdetails.ID != 0 && patdetails.ID != null){
            sqlQuery = sqlQuery + " AND ID= " + patdetails.ID;
            }

            if (patdetails.Name != string.Empty && patdetails.Name != null)
            {
                sqlQuery = sqlQuery + " AND Name= '" + patdetails.Name + "'";
            }

            if ((patdetails.Phone != string.Empty) && (patdetails.Phone !=null))
            {
                sqlQuery = sqlQuery + " AND phone= '" + patdetails.Phone + "'";
            }

            if (patdetails.EmergencyContact != string.Empty && patdetails.EmergencyContact != null)
            {
                sqlQuery = sqlQuery + " AND EmergencyContact= '" + patdetails.EmergencyContact + "'";
            }

            if (patdetails.DateOfBirth != string.Empty && patdetails.DateOfBirth != null)
            {
                sqlQuery = sqlQuery + " AND DOB= 'CONVERT(VARCHAR(12)," + patdetails.DateOfBirth + ", 101)'";
            }

            if (patdetails.DateOfRegistration != string.Empty && patdetails.DateOfRegistration != null)
            {
                sqlQuery = sqlQuery + " AND DateOfRegistration= '" + patdetails.DateOfRegistration + "'";
            }


            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            List<patient> pat = new List<patient>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                pat.Add(new patient
                {
                    ID = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    Address = row[2].ToString(),
                    DateOfBirth = row[3].ToString(),
                    Phone = row[4].ToString(),
                    EmergencyContact = row[5].ToString(),
                    DateOfRegistration = row[6].ToString()
                });
            }
            con.Close();

            return pat;

        }
    }
}