﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
	public class NewsletterGateway {

		private static String SELECT_NEWSLETTERS = "SELECT idnewsletter, data_creazione, titolo, testo FROM newsletter";
		private static String SELECT_NEWSLETTER_BY_ID = "SELECT idnewsletter, data_creazione, titolo, testo FROM newsletter WHERE idnewsletter = @idnewsletter";
		private static String INSERT_NEWSLETTER = "INSERT INTO newsletter (idnewsletter, data_creazione, titolo, testo) VALUES (@idnewsletter, @data_creazione, @titolo, @testo)";
		private static String UPDATE_NEWSLETTER = "UPDATE newsletter  SET data_creazione = @data_creazione , titolo = @titolo, testo = @testo WHERE idnewsletter = @idnewsletter";

		/// <summary>
		/// SELECT NEWSLETTERS
		/// </summary>
		/// <returns></returns>
		internal static DataView SelectNewsletters() {
			DataView dv = new DataView();
			using (MySqlConnection conn = ConnectionGateway.ConnectDB())
			using (MySqlCommand cmd = new MySqlCommand(SELECT_NEWSLETTERS, conn))
			using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
				try {
					conn.Open();
					DataTable dt = new DataTable();
					adapter.Fill(dt);
					dv = dt.DefaultView;

					return dv;
				} catch (MySqlException) {
					return dv;
				}
			}
		}

		/// <summary>
		/// Selezione della Newsletter da processare dato l'id
		/// </summary>
		/// <param name="newsletterId"></param>
		/// <returns></returns>
		internal static NewsletterEntity SelectNewsletter(int newsletterId) {
			NewsletterEntity newsletter = new NewsletterEntity();

			using (MySqlConnection conn = ConnectionGateway.ConnectDB())
			using (MySqlCommand cmd = new MySqlCommand(SELECT_NEWSLETTER_BY_ID, conn))
			using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
				try {
					conn.Open();
					DataTable dt = new DataTable();
					cmd.Parameters.AddWithValue("idnewsletter", newsletterId);
					adapter.Fill(dt);
					foreach (DataRow row in dt.Rows) {
						newsletter.data_creazione = DateTime.Parse(row["data_creazione"].ToString());
						newsletter.testo = row["testo"].ToString();
						newsletter.titolo = row["titolo"].ToString();
					}
					return newsletter;
				} catch (MySqlException ex) {
					return new NewsletterEntity();
				}
			}
		}

		/// <summary>
		/// DELETE NEWSLETTERS (A list of Newsletter)
		/// </summary>
		/// <param name="NewslettersIdToBeErased"></param>
		/// <returns></returns>
		internal static Boolean DeleteNewsletter(List<Int32> NewslettersIdToBeErased) {
			String _DELETE_NEWSLETTERS = "DELETE FROM newsletter WHERE @ComposedConditions";
			MySqlConnection conn = ConnectionGateway.ConnectDB();

			StringBuilder sb = new StringBuilder();
			foreach (int item in NewslettersIdToBeErased) {
				sb.Append("idnewsletter = " + item.ToString() + " OR ");
			}
			sb.Append("1=0");

			_DELETE_NEWSLETTERS = _DELETE_NEWSLETTERS.Replace("@ComposedConditions", sb.ToString());
			MySqlCommand command = new MySqlCommand(_DELETE_NEWSLETTERS, conn);
			command.CommandType = CommandType.Text;
			try {
				conn.Open();
				command.ExecuteNonQuery();
			} catch (MySqlException) {
				return false;
			} finally {
				conn.Close();
			}
			return true;
		}

		/// <summary>
		/// UPDATE NEWSLETTER
		/// </summary>
		/// <param name="MyNewsletter"></param>
		/// <returns></returns>
		internal static Boolean UpdateNewsletter(NewsletterEntity MyNewsletter) {
			MySqlConnection conn = ConnectionGateway.ConnectDB();

			MySqlCommand command = new MySqlCommand(UPDATE_NEWSLETTER, conn);
			command.CommandType = CommandType.Text;
			command.Parameters.AddWithValue("idnewsletter", MyNewsletter.id);
			command.Parameters.AddWithValue("data_creazione", MyNewsletter.data_creazione);
			command.Parameters.AddWithValue("titolo", MyNewsletter.titolo);
			command.Parameters.AddWithValue("testo", MyNewsletter.testo);

			try {
				conn.Open();
				command.ExecuteNonQuery();
			} catch (MySqlException) {
				return false;
			} finally {
				conn.Close();
			}
			return true;
		}

		/// <summary>
		/// INSERT NEWSLETTER
		/// </summary>
		/// <param name="MyNewsletter"></param>
		/// <returns></returns>
		internal static Boolean InsertNewsletter(NewsletterEntity MyNewsletter) {
			MySqlConnection conn = ConnectionGateway.ConnectDB();

			MySqlCommand command = new MySqlCommand(INSERT_NEWSLETTER, conn);
			command.CommandType = CommandType.Text;
			command.Parameters.AddWithValue("idnewsletter", MyNewsletter.id);
			command.Parameters.AddWithValue("data_creazione", MyNewsletter.data_creazione);
			command.Parameters.AddWithValue("titolo", MyNewsletter.titolo);
			command.Parameters.AddWithValue("testo", MyNewsletter.testo);
			try {
				conn.Open();
				command.ExecuteNonQuery();
			} catch (MySql.Data.MySqlClient.MySqlException) {
				return false;
			} finally {
				conn.Close();
			}
			return true;
		}

		internal static void DistributeNewsletterMailsToSelectedUsers(System.Web.UI.WebControls.ListItemCollection listItemCollection, List<NewsletterEntity> selectedNewsletters) {
			MailGateway.SendNewsletters(listItemCollection, selectedNewsletters);
		}
	}
}