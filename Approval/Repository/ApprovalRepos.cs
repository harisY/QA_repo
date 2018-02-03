using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Approval.Models;
using System.Configuration;

namespace Approval.Repository
{
    public class ApprovalRepos
    {
        private SqlConnection con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public List<ApprovalModel> GetAllApproval()
        {
            Connection();
            List<ApprovalModel> ApprovalList = new List<ApprovalModel>();
            string Query = @"select 
                                quote_id, 
                                order_id, 
                                date_trans, 
                                quote_value, 
                                ship_from_city, 
                                ship_to_city, 
                                ship_type, 
                                lead_time,
                                lead_time_days
                            from sales_quote order by order_id";
            SqlCommand com = new SqlCommand(Query, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ApprovalList.Add(
                    new ApprovalModel
                    {
                        quote_id = Convert.ToString(dr["quote_id"]),
                        order_id = Convert.ToString(dr["order_id"]),
                        date_trans = Convert.ToString(dr["date_trans"]),
                        quote_value = Convert.ToDecimal(dr["quote_value"]),
                        ship_from_city = Convert.ToString(dr["ship_from_city"]),
                        ship_to_city = Convert.ToString(dr["ship_to_city"]),
                        ship_type = Convert.ToString(dr["ship_type"]),
                        lead_time = Convert.ToInt32(dr["lead_time"]),
                        lead_time_days = Convert.ToString(dr["lead_time_days"])
                    });
            }
            return ApprovalList;

        }

        public List<ApprovalModel> GetDetailsApproval(string quote_id)
        {
            Connection();
            List<ApprovalModel> detailsApproval = new List<ApprovalModel>();
            string Query = @"SELECT 
                                sales_quote.quote_id, 
                                sales_quote.order_id, 
                                sales_quote.date_trans, 
                                PartnerDB.CompanyName AS cust_name, 
                                sales_quote.ship_from_city, 
                                sales_quote.ship_to_city, 
                                sales_quote.quote_value, 
                                tbl_tipe_barang.description AS goods, 
                                sales_quote.ship_type, 
                                sales_quote.lead_time, 
                                sales_quote.lead_time_days, 
                                sales_quote.term_pay_code AS top_code, 
                                sales_quote.status, 
                                wf_action_type.action_type_name, 
                                termpayment.Description AS top_desc, 
                                termpayment.[Due Date Calculation] AS top_days, 
                                sales_quote.ship_desc_1, 
                                sales_quote.ship_desc_2, 
                                sales_quote.ship_desc_3, 
                                sales_quote.created_by, 
                                sales_quote.approved_1_by, 
                                sales_quote.approved_2_by, 
                                sales_quote.approved_3_by, 
                                sales_quote.approved_1_date, 
                                sales_quote.approved_2_date, 
                                sales_quote.approved_3_date, 
                                sales_quote.approve_1_sign, 
                                sales_quote.approve_2_sign, 
                                sales_quote.approve_3_sign
                            FROM    
                                sales_quote INNER JOIN
                                PartnerDB ON sales_quote.partner_id = PartnerDB.PartnerID INNER JOIN
                                tbl_tipe_barang ON sales_quote.item_id = tbl_tipe_barang.id INNER JOIN
                                wf_action_type ON sales_quote.status = wf_action_type.action_type_id INNER JOIN
                                termpayment ON sales_quote.term_pay_code = termpayment.Code where sales_quote.quote_id = '" + quote_id + "'";
            SqlCommand com = new SqlCommand(Query, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                detailsApproval.Add(
                    new ApprovalModel
                    {
                        quote_id = Convert.ToString(dr["quote_id"]),
                        order_id = Convert.ToString(dr["order_id"]),
                        date_trans = Convert.ToString(dr["date_trans"]),
                        quote_value = Convert.ToDecimal(dr["quote_value"]),
                        ship_from_city = Convert.ToString(dr["ship_from_city"]),
                        ship_to_city = Convert.ToString(dr["ship_to_city"]),
                        ship_type = Convert.ToString(dr["ship_type"]),
                        lead_time = Convert.ToInt32(dr["lead_time"]),
                        lead_time_days = Convert.ToString(dr["lead_time_days"]),
                        term_pay_code = Convert.ToString(dr["top_code"]),
                        status = Convert.ToInt32(dr["status"]),
                        ship_desc_1 = Convert.ToString(dr["ship_desc_1"]),
                        ship_desc_2 = Convert.ToString(dr["ship_desc_2"]),
                        ship_desc_3 = Convert.ToString(dr["ship_desc_3"]),
                        customer = Convert.ToString(dr["cust_name"]),
                        goods = Convert.ToString(dr["goods"]),
                        action_type_name = Convert.ToString(dr["action_type_name"]),
                        top_days = Convert.ToString(dr["top_days"]),
                        top_desc = Convert.ToString(dr["top_desc"]),
                    });
            }
            return detailsApproval;

        }
    }
}