using ContactInfo.Infrastructure.Data.Interfaces;
using ContactInfo.Infrastructure.Data.Models;
using ContactInfo.Infrastructure.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactInfo.Infrastructure.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IConfiguration _configuration;
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ContactDB_Dev;Trusted_Connection=True;MultipleActiveResultSets=true";
        public IEnumerable<Contact> GetAll()
        {
            //var connString = _configuration["ContactConnection"];            
            //List<Contact> contacts = new List<Contact> {
            //new Contact{FirstName="Khizar",LastName="Bojagar",Mobile="9923664949",Email="khizar@gmail.com",ImageURL="/Images/Khizar.png"}            
            //};

            List<Contact> contacts = new List<Contact>();
            using (SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("SP_GetAllContacts", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    Contact objContact = new Contact();
                    objContact.Id = Convert.ToInt32(dr["Id"].ToString());
                    objContact.FirstName = dr["FirstName"].ToString();
                    objContact.LastName = dr["LastName"].ToString();
                    objContact.Mobile = dr["Mobile"].ToString();
                    objContact.Email = dr["Email"].ToString();
                    objContact.ImageURL = dr["ImageURL"].ToString();
                    objContact.ContactsGroupsGroupId = Convert.ToInt32(dr["Id"].ToString());
                    contacts.Add(objContact);
                }
                
            }
            return contacts;
        }

        public Contact GetById(int Id)
        {
            Contact contact = new Contact();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllContacts", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iId", Id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contact.Id = Convert.ToInt32(dr["Id"].ToString());
                    contact.FirstName = dr["FirstName"].ToString();
                    contact.LastName = dr["LastName"].ToString();
                    contact.Mobile = dr["Mobile"].ToString();
                    contact.Email = dr["Email"].ToString();
                    contact.ContactsGroupsGroupId = Convert.ToInt32(dr["Id"].ToString());                    
                }

            }
            return contact;
        }

        public ContactDetails GetDetailsById(int id)
        {
            //List<ContactDetails> contactDetails = new List<ContactDetails> {
           // return new ContactDetails { FirstName = "Khizar", LastName = "Bojagar", Mobile = "9923664949", Email = "khizar@gmail.com", GroupName = "Family" };
            //new Contact{FirstName="Sidra",LastName="Bojagar",Mobile="9923664949",Email="sidra@gmail.com" }
            //};

            ContactDetails contact = new ContactDetails();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetContactDetailsById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iId", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contact.Id = Convert.ToInt32(dr["Id"].ToString());
                    contact.FirstName = dr["FirstName"].ToString();
                    contact.LastName = dr["LastName"].ToString();
                    contact.Mobile = dr["Mobile"].ToString();
                    contact.Email = dr["Email"].ToString();
                    contact.ImageURL = dr["ImageURL"].ToString();
                    contact.GroupName = dr["GroupName"].ToString();
                }

            }
            return contact;
        }

        public void AddContact(Contact _contact)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertContact", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sFname",_contact.FirstName);
                cmd.Parameters.AddWithValue("@sLastName", _contact.LastName);
                cmd.Parameters.AddWithValue("@sMobile", _contact.Mobile);
                cmd.Parameters.AddWithValue("@sEmail", _contact.Email);
                cmd.Parameters.AddWithValue("@iGroupId", _contact.ContactsGroupsGroupId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateContact(Contact _contact)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateContact", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iId", _contact.Id);
                cmd.Parameters.AddWithValue("@sFname", _contact.FirstName);
                cmd.Parameters.AddWithValue("@sLastName", _contact.LastName);
                cmd.Parameters.AddWithValue("@sMobile", _contact.Mobile);
                cmd.Parameters.AddWithValue("@sEmail", _contact.Email);
                cmd.Parameters.AddWithValue("@iGroupId", _contact.ContactsGroupsGroupId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteContact", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iId", id);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        
    }
}
