using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.BE;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.DAL.SQL
{
    public class DAL_User_SQL : DAL_Abstract<User>
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private static Encrypt ENCRYPTION_SERVICE = new Encrypt();

        //table names
        private const string TABLE_user = "account";
        private const string TABLE_password = "passwordHash";
        private const string TABLE_userStatus = "accountStatus";
        private const string TABLE_address = "UserAdress";
        private const string TABLE_provinces = "Provinces";
        private const string TABLE_SPECIALITY = "MedicalSpeciality";
        private const string TABLE_PROCEDURES = "Procedures";
        private const string TABLE_ACCOUNT_SPECIALITY = "account_speciality";
        private const string TABLE_APPOINTMENT = "Appointment";

        //user table columns
        private const string COLUMN_USER_ID = "id";
        private const string COLUMN_USER_USERNAME = "username";
        private const string COLUMN_USER_EMAIL = "email";
        private const string COLUMN_USER_LANGUAGE = "FK_language_account";
        private const string COLUMN_USER_NAME = "name";
        private const string COLUMN_USER_LASTNAME = "lastName";
        private const string COLUMN_USER_BIRTHDATE = "birthdate";
        private const string COLUMN_USER_DNI = "dni";
        private static readonly string PARAM_USER_ID = $"@{COLUMN_USER_ID}";
        private static readonly string PARAM_USER_USERNAME = $"@{COLUMN_USER_USERNAME}";
        private static readonly string PARAM_USER_EMAIL = $"@{COLUMN_USER_EMAIL}";
        private static readonly string PARAM_USER_LANGUAGE = $"@{COLUMN_USER_LANGUAGE}";
        private static readonly string PARAM_USER_NAME = $"@{COLUMN_USER_NAME}";
        private static readonly string PARAM_USER_LASTNAME = $"@{COLUMN_USER_LASTNAME}";
        private static readonly string PARAM_USER_BIRTHDATE = $"@{COLUMN_USER_BIRTHDATE}";
        private static readonly string PARAM_USER_DNI = $"@{COLUMN_USER_DNI}";

        //password table columns
        private const string COLUMN_PASSWORD_ID = "id";
        private const string COLUMN_PASSWORD_PASSHASH = "passHash";
        private const string COLUMN_PASSWORD_FK_ACCOUNT = "FK_account_passwordhash";
        private const string COLUMN_PASSWORD_ADD_DATE = "addDate";
        private static readonly string PARAM_PASSWORD_ID = $"@{COLUMN_PASSWORD_ID}";
        private static readonly string PARAM_PASSWORD_PASSHASH = $"@{COLUMN_PASSWORD_PASSHASH}";
        private static readonly string PARAM_PASSWORD_FK_ACCOUNT = $"@{COLUMN_PASSWORD_FK_ACCOUNT}";
        private static readonly string PARAM_PASSWORD_ADD_DATE = $"@{COLUMN_PASSWORD_ADD_DATE}";

        //user status table columns
        private const string COLUMN_USERSTATUS_ID = "id";
        private const string COLUMN_USERSTATUS_BLOCKED = "isBlocked";
        private const string COLUMN_USERSTATUS_ATTEMPTS = "attempts";
        private const string COLUMN_USERSTATUS_FK_ACCOUNT = "FK_account_accountstatus";
        private static readonly string PARAM_USERSTATUS_ID = $"@{COLUMN_USERSTATUS_ID}";
        private static readonly string PARAM_USERSTATUS_BLOCKED = $"@{COLUMN_USERSTATUS_BLOCKED}";
        private static readonly string PARAM_USERSTATUS_ATTEMPTS = $"@{COLUMN_USERSTATUS_ATTEMPTS}";
        private static readonly string PARAM_USERSTATUS_KF_ACCOUNT = $"@{COLUMN_USERSTATUS_FK_ACCOUNT}";

        //user address table columns
        private const string COLUMN_ADDRESS_ID = "id";
        private const string COLUMN_ADDRESS_ADDRESS1 = "Address1";
        private const string COLUMN_ADDRESS_ADDRESS2 = "Address2";
        private const string COLUMN_ADDRESS_ADDRESSNumber = "AddressNumber";
        private const string COLUMN_ADDRESS_FK_City = "FK_City";
        private const string COLUMN_ADDRESS_FK_Province = "FK_Province";
        private const string COLUMN_ADDRESS_FK_Account = "FK_Account";
        private const string COLUMN_ADDRESS_ISOFFICE = "isOffice";
        private static readonly string PARAM_ADDRESS_ID = $"@{COLUMN_ADDRESS_ID}";
        private static readonly string PARAM_ADDRESS_ADDRESS1 = $"@{COLUMN_ADDRESS_ADDRESS1}";
        private static readonly string PARAM_ADDRESS_ADDRESS2 = $"@{COLUMN_ADDRESS_ADDRESS2}";
        private static readonly string PARAM_ADDRESS_ADDRESSNumber = $"@{COLUMN_ADDRESS_ADDRESSNumber}";
        private static readonly string PARAM_ADDRESS_FK_City = $"@{COLUMN_ADDRESS_FK_City}";
        private static readonly string PARAM_ADDRESS_FK_Province = $"@{COLUMN_ADDRESS_FK_Province}";
        private static readonly string PARAM_ADDRESS_FK_ACCOUNT = $"@{COLUMN_ADDRESS_FK_Account}";
        private static readonly string PARAM_ADDRESS_ISOFFICE = $"@{COLUMN_ADDRESS_ISOFFICE}";

        //Provinces table columns
        private const string COLUMN_PROVINCES_ID = "Id";
        private const string COLUMN_PROVINCES_NAME = "name";
        private static readonly string PARAM_PROVINCES_ID = $"@{COLUMN_PROVINCES_ID}";
        private static readonly string PARAM_PROVINCES_NAME = $"@{COLUMN_PROVINCES_NAME}";

        //Medical Speciality columns
        private const string COLUMN_MEDICALSPEC_ID = "id";
        private const string COLUMN_MEDICALSPEC_NAME = "name";
        private const string COLUMN_MEDICALSPEC_DESC = "description";
        private static readonly string PARAM_MEDICALSPEC_ID = $"@{COLUMN_MEDICALSPEC_ID}";
        private static readonly string PARAM_MEDICALSPEC_NAME = $"@{COLUMN_MEDICALSPEC_NAME}";
        private static readonly string PARAM_MEDICALSPEC_DESC = $"@{COLUMN_MEDICALSPEC_DESC}";

        //Procedures columns
        private const string COLUMN_PROCEDURES_ID = "id";
        private const string COLUMN_PROCEDURES_IDACCOUNT = "id_account";
        private const string COLUMN_PROCEDURES_NAME = "Name";
        private const string COLUMN_PROCEDURES_DESCRIPTION = "Description";
        private const string COLUMN_PROCEDURES_COST = "Cost";
        private static readonly string PARAM_PROCEDURES_ID = $"@{COLUMN_MEDICALSPEC_DESC}";
        private static readonly string PARAM_PROCEDURES_IDACCOUNT = $"@{COLUMN_PROCEDURES_IDACCOUNT}";
        private static readonly string PARAM_PROCEDURES_NAME = $"@{COLUMN_PROCEDURES_NAME}";
        private static readonly string PARAM_PROCEDURES_DESCRIPTION = $"@{COLUMN_PROCEDURES_DESCRIPTION}";
        private static readonly string PARAM_PROCEDURES_COST = $"@{COLUMN_PROCEDURES_COST}";

        //Account speciality columns
        private const string COLUMN_ACCOUNT_SPECIALITY_FKACCOUNT = "FK_id_account";
        private const string COLUMN_ACCOUNT_SPECIALITY_FKSPECIALITY = "FK_id_speciality";
        private static readonly string PARAM_ACCOUNT_SPECIALITY_FKACCOUNT = $"@{COLUMN_ACCOUNT_SPECIALITY_FKACCOUNT}";
        private static readonly string PARAM_ACCOUNT_SPECIALITY_FKSPECIALITY = $"@{COLUMN_ACCOUNT_SPECIALITY_FKSPECIALITY}";

        //Appointment columns
        private const string COLUMN_APPOINTMENT_ID = "id";
        private const string COLUMN_APPOINTMENT_FKACCOUNT = "FK_Account";
        private const string COLUMN_APPOINTMENT_FKPRACTITIONER = "FK_Practitioner";
        private const string COLUMN_APPOINTMENT_FKOFFICE = "FK_Office";
        private const string COLUMN_APPOINTMENT_FKPROCEDURE = "FK_Procedure";
        private const string COLUMN_APPOINTMENT_TIME_PROCESS = "TimeProcess";
        private const string COLUMN_APPOINTMENT_TIME_APPOINTMENT = "TimeAppointment";
        private const string COLUMN_APPOINTMENT_CONFIRMED = "Confirmed";
        private static readonly string PARAM_APPOINTMENT_ID = $"@{COLUMN_APPOINTMENT_ID}";
        private static readonly string PARAM_APPOINTMENT_FKACCOUNT = $"@{COLUMN_APPOINTMENT_FKACCOUNT}";
        private static readonly string PARAM_APPOINTMENT_FKPRACTITIONER = $"@{COLUMN_APPOINTMENT_FKPRACTITIONER}";
        private static readonly string PARAM_APPOINTMENT_FKOFFICE = $"@{COLUMN_APPOINTMENT_FKOFFICE}";
        private static readonly string PARAM_APPOINTMENT_FKPROCEDURE = $"@{COLUMN_APPOINTMENT_FKPROCEDURE}";
        private static readonly string PARAM_APPOINTMENT_TIME_PROCESS = $"@{COLUMN_APPOINTMENT_TIME_PROCESS}";
        private static readonly string PARAM_APPOINTMENT_TIME_APPOINTMENT = $"@{COLUMN_APPOINTMENT_TIME_APPOINTMENT}";
        private static readonly string PARAM_APPOINTMENT_CONFIRMED = $"@{COLUMN_APPOINTMENT_CONFIRMED}";


        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public User findByUsername(string pUsername)
        {
            User user = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_user}.{COLUMN_USER_ID}, {TABLE_user}.{COLUMN_USER_USERNAME}, {TABLE_user}.{COLUMN_USER_EMAIL}, {TABLE_user}.{COLUMN_USER_NAME}, {TABLE_user}.{COLUMN_USER_LASTNAME}, {TABLE_user}.{COLUMN_USER_BIRTHDATE}, {TABLE_user}.{COLUMN_USER_DNI}, {TABLE_userStatus}.{COLUMN_USERSTATUS_BLOCKED}, {TABLE_userStatus}.{COLUMN_USERSTATUS_ATTEMPTS}" +
                                $" FROM {TABLE_user}" +
                                $" INNER JOIN {TABLE_userStatus} ON {TABLE_user}.{COLUMN_USER_ID} = {TABLE_userStatus}.{COLUMN_USERSTATUS_FK_ACCOUNT}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_USERNAME} = '{pUsername}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows) 
                    {
                        while (sqlReader.Read())
                        {
                            user = new User(new object[] {(int) sqlReader[0],
                                                    (string) sqlReader[1],
                                                    (string) sqlReader[2],
                                                    (string) sqlReader[3],
                                                    (string) sqlReader[4], 
                                                    (DateTime) sqlReader[5], 
                                                    (int) sqlReader[6]});

                            user.IsBlocked = (bool)sqlReader[7];
                            user.Attempts = (int)sqlReader[8];
                        }
                    }
                    sqlReader.Close();
                }
            }
            return user;
        }
        public bool userPasswordMatcher(int pId, string inputPassword)
        {
            bool matches = false;
            string storesPass = "";

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                //string query = $"SELECT {COLUMN_PASSWORD_PASSHASH}" +
                //                $" FROM {TABLE_password}" +
                //                $" WHERE {TABLE_password}.{COLUMN_PASSWORD_FK_ACCOUNT} = {pId}";

                string query = $"SELECT TOP 1 {TABLE_password}.{COLUMN_PASSWORD_PASSHASH}" +
                                $" FROM {TABLE_password}" +
                                $" WHERE {TABLE_password}.{COLUMN_PASSWORD_FK_ACCOUNT} = {PARAM_USERSTATUS_KF_ACCOUNT}" +
                                $" ORDER BY {TABLE_password}.{COLUMN_PASSWORD_ADD_DATE} DESC";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_KF_ACCOUNT, pId);

                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            storesPass = (string)sqlReader[0];
                            storesPass = storesPass.Replace(" ", string.Empty);
                        }
                    }
                    sqlReader.Close();
                }
            }

            Encrypt serviceEncryption = new Encrypt();

            if (serviceEncryption.hashComparer(inputPassword, storesPass))
            {
                matches = true;
            }

            return matches;
        }
        public void UpdateUserStatus(User Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string query = $"UPDATE {TABLE_userStatus}" +
                                $" SET {COLUMN_USERSTATUS_BLOCKED} = {PARAM_USERSTATUS_BLOCKED}, {COLUMN_USERSTATUS_ATTEMPTS} = {PARAM_USERSTATUS_ATTEMPTS}" +
                                $" FROM {TABLE_userStatus}" +
                                $" INNER JOIN {TABLE_user} ON {TABLE_user}.{COLUMN_USER_ID} = {TABLE_userStatus}.{COLUMN_USERSTATUS_FK_ACCOUNT}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_ID} = {Entity.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_BLOCKED, Entity.IsBlocked);
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_ATTEMPTS, Entity.Attempts);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        private int getUserId(User Entity)
        {
            int id = 0;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT MAX({COLUMN_USER_ID})" +
                                $" FROM {TABLE_user}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_USERNAME} LIKE '{Entity.Username}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            id = (int)sqlReader[0];
                        }
                    }
                    sqlReader.Close();
                }
            }
            
            return id;
        }

        public User Save(User Entity)
        {
            Entity.IsBlocked = false;
            Entity.Attempts = 0;
            Entity.Password = ENCRYPTION_SERVICE.hasher(Entity.Password);

            //Saving User
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query =  $"INSERT INTO {TABLE_user} ({COLUMN_USER_USERNAME}, {COLUMN_USER_EMAIL}, {COLUMN_USER_LANGUAGE}, {COLUMN_USER_NAME}, {COLUMN_USER_LASTNAME}, {COLUMN_USER_BIRTHDATE}, {COLUMN_USER_DNI})" +
                                $" VALUES ({PARAM_USER_USERNAME}, {PARAM_USER_EMAIL}, {PARAM_USER_LANGUAGE}, {PARAM_USER_NAME}, {PARAM_USER_LASTNAME}, {PARAM_USER_BIRTHDATE}, {PARAM_USER_DNI})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_ID, Entity.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_USERNAME, Entity.Username);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_EMAIL, Entity.Email);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_LANGUAGE, 1);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_NAME, Entity.Name);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_LASTNAME, Entity.LastName);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_BIRTHDATE, Entity.Birthdate);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_DNI, Entity.Dni);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }

            //After saving the user we need to retrieve the auto generated ID from the DB, in order to save Pass ans Status.
            Entity.Id = getUserId(Entity);

            SavePassword(Entity);
            SaveStatus(Entity);

            return Entity;
        }

        public void SavePassword(User Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_password} ( {COLUMN_PASSWORD_PASSHASH}, {COLUMN_PASSWORD_FK_ACCOUNT})" +
                                $" VALUES ({PARAM_PASSWORD_PASSHASH}, {PARAM_PASSWORD_FK_ACCOUNT})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_PASSHASH, Entity.Password);
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_FK_ACCOUNT, Entity.Id);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void SaveStatus(User Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_userStatus} ({COLUMN_USERSTATUS_BLOCKED}, {COLUMN_USERSTATUS_ATTEMPTS}, {COLUMN_USERSTATUS_FK_ACCOUNT})" +
                                $" VALUES ( {PARAM_USERSTATUS_BLOCKED}, {PARAM_USERSTATUS_ATTEMPTS}, {PARAM_USERSTATUS_KF_ACCOUNT})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_BLOCKED, Entity.IsBlocked);
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_ATTEMPTS, Entity.Attempts);
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_KF_ACCOUNT, Entity.Id);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void UpdateLanguage(User Entity, Language language)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string query = $"UPDATE {TABLE_user}" +
                                $" SET {TABLE_user}.{COLUMN_USER_LANGUAGE} = {PARAM_USER_LANGUAGE}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_ID} = {PARAM_USER_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_LANGUAGE, language.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_ID, Entity.Id);

                    sqlCommand.ExecuteNonQuery();
                }
            }

        }

        //needs implementation
        public IList<User> GetAll()
        {

            List<User> userList = new List<User>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_user}.{COLUMN_USER_ID}, {TABLE_user}.{COLUMN_USER_USERNAME}, {TABLE_user}.{COLUMN_USER_EMAIL}, {TABLE_user}.{COLUMN_USER_NAME}, {TABLE_user}.{COLUMN_USER_LASTNAME}, {TABLE_user}.{COLUMN_USER_BIRTHDATE}, {TABLE_user}.{COLUMN_USER_DNI}" +
                                $" FROM {TABLE_user}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            userList.Add(new User(new object[] {(int) sqlReader[0],
                                                    (string) sqlReader[1],
                                                    (string) sqlReader[2],
                                                    (string) sqlReader[3],
                                                    (string) sqlReader[4],
                                                    (DateTime) sqlReader[5],
                                                    (int) sqlReader[6]}));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return userList.ToList();
        }

        public bool blockAccount(User user)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string query = $"UPDATE {TABLE_userStatus}" +
                                $" SET {TABLE_userStatus}.{COLUMN_USERSTATUS_BLOCKED} = 'True'" +
                                $" FROM {TABLE_userStatus}" +
                                $" INNER JOIN {TABLE_user}" +
                                $" ON {TABLE_user}.{COLUMN_USER_ID} = {TABLE_userStatus}.{COLUMN_USERSTATUS_FK_ACCOUNT}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_ID} = {user.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        public bool unblockAccount(User user)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string query = $"UPDATE {TABLE_userStatus}" +
                                $" SET {TABLE_userStatus}.{COLUMN_USERSTATUS_BLOCKED} = 'False', {TABLE_userStatus}.{COLUMN_USERSTATUS_ATTEMPTS} = 0" +
                                $" FROM {TABLE_userStatus}" +
                                $" INNER JOIN {TABLE_user}" +
                                $" ON {TABLE_user}.{COLUMN_USER_ID} = {TABLE_userStatus}.{COLUMN_USERSTATUS_FK_ACCOUNT}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_ID} = {user.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }
        public bool changePassword(User user, string password)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_password} ({COLUMN_PASSWORD_PASSHASH}, {COLUMN_PASSWORD_FK_ACCOUNT}, {COLUMN_PASSWORD_ADD_DATE})" +
                                $" VALUES ( {PARAM_PASSWORD_PASSHASH}, {PARAM_PASSWORD_FK_ACCOUNT}, {PARAM_PASSWORD_ADD_DATE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_PASSHASH, ENCRYPTION_SERVICE.hasher(password));
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_FK_ACCOUNT, user.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_ADD_DATE, DateTime.Now);

                    try
                    {
                        int changes = sqlCommand.ExecuteNonQuery();

                        if (changes == 1)
                        {
                            success = true;
                        }
                    }
                    catch (Exception)
                    { }
                   
                }

                sqlConnection.Close();
            }

            return success;
        }
        public Address getUserAddress(User user)
        {
            Address address = null;
            Province province = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_address}.{COLUMN_ADDRESS_ADDRESS1}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ADDRESS2}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ADDRESSNumber}," +
                                        $" {TABLE_provinces}.{COLUMN_PROVINCES_NAME}," +
                                        $" {TABLE_provinces}.{COLUMN_PROVINCES_ID}" +
                                $" FROM {TABLE_address}" +
                                $" INNER JOIN {TABLE_provinces}" +
                                $" ON {TABLE_provinces}.{COLUMN_PROVINCES_ID} = {TABLE_address}.{COLUMN_ADDRESS_FK_Province}" +
                                $" WHERE {TABLE_address}.{COLUMN_ADDRESS_FK_Account} = {PARAM_ADDRESS_FK_ACCOUNT} " +
                                $" AND {TABLE_address}.{COLUMN_ADDRESS_ISOFFICE} = 0";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_ACCOUNT, user.Id);
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        address = new Address();
                        province = new Province();

                        while (sqlReader.Read())
                        {
                            address.Address1 = (string)sqlReader[0];
                            address.Address2 = (string)sqlReader[1];
                            address.AddressNumber = (int)sqlReader[2];
                            province.name = (string)sqlReader[3];
                            province.id = (int)sqlReader[4];

                            address.Province = province;
                        }
                    }
                    sqlReader.Close();
                }
            }

            return address;
        }
        public List<Address> getAllOffices(User user)
        {
            List<Address> addressList = new List<Address>();

            Address address = null;
            Province province = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_address}.{COLUMN_ADDRESS_ADDRESS1}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ADDRESS2}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ADDRESSNumber}," +
                                        $" {TABLE_provinces}.{COLUMN_PROVINCES_NAME}," +
                                        $" {TABLE_provinces}.{COLUMN_PROVINCES_ID}" +
                                $" FROM {TABLE_address}" +
                                $" INNER JOIN {TABLE_provinces}" +
                                $" ON {TABLE_provinces}.{COLUMN_PROVINCES_ID} = {TABLE_address}.{COLUMN_ADDRESS_FK_Province}" +
                                $" WHERE {TABLE_address}.{COLUMN_ADDRESS_FK_Account} = {PARAM_ADDRESS_FK_ACCOUNT} " +
                                $" AND {TABLE_address}.{COLUMN_ADDRESS_ISOFFICE} = 1";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_ACCOUNT, user.Id);
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            address = new Address();
                            province = new Province();

                            address.Address1 = (string)sqlReader[0];
                            address.Address2 = (string)sqlReader[1];
                            address.AddressNumber = (int)sqlReader[2];
                            province.name = (string)sqlReader[3];
                            province.id = (int)sqlReader[4];

                            address.Province = province;

                            addressList.Add(address);
                        }
                    }
                    sqlReader.Close();
                }
            }

            return addressList;
        }

        public bool addUserAddress(Address address, User user)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_address} ({COLUMN_ADDRESS_FK_Account}," +
                                                           $" {COLUMN_ADDRESS_ADDRESS1}," +
                                                           $" {COLUMN_ADDRESS_ADDRESS2}," +
                                                           $" {COLUMN_ADDRESS_ADDRESSNumber}," +
                                                           $" {COLUMN_ADDRESS_FK_Province}," +
                                                           $" {COLUMN_ADDRESS_ISOFFICE})" +
                                $" VALUES ( {PARAM_ADDRESS_FK_ACCOUNT}, " +
                                         $" {PARAM_ADDRESS_ADDRESS1}," +
                                         $" {PARAM_ADDRESS_ADDRESS2}," +
                                         $" {PARAM_ADDRESS_ADDRESSNumber}," +
                                         $" {PARAM_ADDRESS_FK_Province}," +
                                         $" {PARAM_ADDRESS_ISOFFICE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_ACCOUNT, user.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ADDRESS1, address.Address1);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ADDRESS2, address.Address2);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ADDRESSNumber, address.AddressNumber);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_Province, address.Province.id);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ISOFFICE, false);

                    try
                    {
                        int changes = sqlCommand.ExecuteNonQuery();

                        if (changes == 1)
                        {
                            success = true;
                        }
                    }
                    catch (Exception)
                    { }

                }

                sqlConnection.Close();
            }

            return success;
        }
        public bool AddOffice(Address address, User user)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_address} ({COLUMN_ADDRESS_FK_Account}," +
                                                           $" {COLUMN_ADDRESS_ADDRESS1}," +
                                                           $" {COLUMN_ADDRESS_ADDRESS2}," +
                                                           $" {COLUMN_ADDRESS_ADDRESSNumber}," +
                                                           $" {COLUMN_ADDRESS_FK_Province}," +
                                                           $" {COLUMN_ADDRESS_ISOFFICE})" +
                                $" VALUES ( {PARAM_ADDRESS_FK_ACCOUNT}, " +
                                         $" {PARAM_ADDRESS_ADDRESS1}," +
                                         $" {PARAM_ADDRESS_ADDRESS2}," +
                                         $" {PARAM_ADDRESS_ADDRESSNumber}," +
                                         $" {PARAM_ADDRESS_FK_Province}," +
                                         $" {PARAM_ADDRESS_ISOFFICE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_ACCOUNT, user.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ADDRESS1, address.Address1);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ADDRESS2, address.Address2);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ADDRESSNumber, address.AddressNumber);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_Province, address.Province.id);
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ISOFFICE, true);

                    try
                    {
                        int changes = sqlCommand.ExecuteNonQuery();

                        if (changes == 1)
                        {
                            success = true;
                        }
                    }
                    catch (Exception)
                    { }

                }

                sqlConnection.Close();
            }

            return success;
        }
        public List<Speciality> getAllSpecialities()
        {
            List<Speciality> specialities = new List<Speciality>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query =  $"SELECT {COLUMN_MEDICALSPEC_ID}, {COLUMN_MEDICALSPEC_NAME}, {COLUMN_MEDICALSPEC_DESC}" +
                                $" FROM {TABLE_SPECIALITY}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            Speciality spec = new Speciality();
                            spec.Id = (int)sqlReader[0];
                            spec.Name = (string)sqlReader[1];
                            spec.Description = (string)sqlReader[2];

                            specialities.Add(spec);
                        }
                    }
                    sqlReader.Close();
                }
            }

            return specialities;
        }
        public List<Procedure> loadProcedures(User user)
        {
            List<Procedure> procedures = new List<Procedure>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PROCEDURES_ID}, {COLUMN_PROCEDURES_NAME}, {COLUMN_PROCEDURES_DESCRIPTION}, {COLUMN_PROCEDURES_COST}" +
                                $" FROM {TABLE_PROCEDURES}" +
                                $" WHERE {COLUMN_PROCEDURES_IDACCOUNT} = {PARAM_PROCEDURES_IDACCOUNT}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_IDACCOUNT, user.Id);

                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            Procedure proc = new Procedure();
                            proc.Id = (int)sqlReader[0];
                            proc.Name = (string)sqlReader[1];
                            proc.Desc = (string)sqlReader[2];
                            proc.Price = (double)sqlReader[3];

                            procedures.Add(proc);
                        }
                    }
                    sqlReader.Close();
                }
            }

            return procedures;
        }
        public bool addProcedure(Procedure procedure, User user)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_PROCEDURES} ( {COLUMN_PROCEDURES_IDACCOUNT}, {COLUMN_PROCEDURES_NAME}, {COLUMN_PROCEDURES_DESCRIPTION}, {COLUMN_PROCEDURES_COST})" +
                                $" VALUES ({PARAM_PROCEDURES_IDACCOUNT}, {PARAM_PROCEDURES_NAME}, {PARAM_PROCEDURES_DESCRIPTION}, {PARAM_PROCEDURES_COST})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_IDACCOUNT, user.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_NAME, procedure.Name);
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_DESCRIPTION, procedure.Desc);
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_COST, procedure.Price);

                    try
                    {
                        int changes = sqlCommand.ExecuteNonQuery();

                        if (changes == 1)
                        {
                            success = true;
                        }
                    }
                    catch (Exception)
                    { }

                }

                sqlConnection.Close();
            }

            return success;
        }
        public bool removeProcedure(Procedure procedure)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE FROM {TABLE_PROCEDURES}" +
                                $" WHERE {COLUMN_PROCEDURES_ID} = {PARAM_PROCEDURES_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_ID, procedure.Id);

                    try
                    {
                        int changes = sqlCommand.ExecuteNonQuery();

                        if (changes == 1)
                        {
                            success = true;
                        }
                    }
                    catch (Exception)
                    { }

                }

                sqlConnection.Close();
            }

            return success;
        }
        public List<User> searchPractitionerResults(Speciality speciality, Province province)
        {
            List<User> userList = new List<User>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_user}.{COLUMN_USER_ID}," +
                                     $" {TABLE_user}.{COLUMN_USER_USERNAME}," +
                                     $" {TABLE_user}.{COLUMN_USER_NAME}," +
                                     $" {TABLE_user}.{COLUMN_USER_LASTNAME}," +
                                     $" {TABLE_user}.{COLUMN_USER_EMAIL}," +
                                     $" {TABLE_user}.{COLUMN_USER_DNI}" +
                              $" FROM {TABLE_user}" +
                              $" INNER JOIN {TABLE_ACCOUNT_SPECIALITY} ON {TABLE_ACCOUNT_SPECIALITY}.{COLUMN_ACCOUNT_SPECIALITY_FKACCOUNT} = {TABLE_user}.{COLUMN_USER_ID}" +
                              $" INNER JOIN {TABLE_SPECIALITY} ON {TABLE_SPECIALITY}.{COLUMN_MEDICALSPEC_ID} = {TABLE_ACCOUNT_SPECIALITY}.{COLUMN_ACCOUNT_SPECIALITY_FKSPECIALITY}" +
                              $" INNER JOIN {TABLE_address} ON {TABLE_address}.{COLUMN_ADDRESS_FK_Account} = {TABLE_user}.{COLUMN_USER_ID}" +
                              $" WHERE {TABLE_address}.{COLUMN_ADDRESS_FK_Province} = {PARAM_ADDRESS_FK_Province}" +
                              $" AND {TABLE_SPECIALITY}.{COLUMN_MEDICALSPEC_ID} = {PARAM_MEDICALSPEC_ID}" +
                              $" AND {TABLE_address}.{COLUMN_ADDRESS_ISOFFICE} = 1";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_FK_Province, province.id);
                    sqlCommand.Parameters.AddWithValue(PARAM_MEDICALSPEC_ID, speciality.Id);

                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            User foundUser = new User();
                            foundUser.Id = (int)sqlReader[0];
                            foundUser.Username = (string)sqlReader[1];
                            foundUser.Name = (string)sqlReader[2];
                            foundUser.LastName = (string)sqlReader[3];
                            foundUser.Email = (string)sqlReader[4];
                            foundUser.Dni = (int)sqlReader[5];

                            userList.Add(foundUser);
                        }
                    }
                    sqlReader.Close();
                }
            }

            return userList.ToList();
        }
        public List<Appointment> getAppointmentsPractitioner(User user)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_ID}, " +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKACCOUNT}," +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKPRACTITIONER}," +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKOFFICE}," +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKPROCEDURE}," +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_TIME_PROCESS}," +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_TIME_APPOINTMENT}," +
                                     $" {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_CONFIRMED} " +
                               $" FROM {TABLE_APPOINTMENT}" +
                               $" INNER JOIN {TABLE_user} AS accClient ON accClient.{COLUMN_USER_ID} = {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKACCOUNT}" +
                               $" INNER JOIN {TABLE_user} AS accPract ON accPract.{COLUMN_USER_ID} = {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKPRACTITIONER}" +
                               $" INNER JOIN {TABLE_address} ON {TABLE_address}.{COLUMN_ADDRESS_ID} = {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKOFFICE}" +
                               $" INNER JOIN {TABLE_PROCEDURES} ON {TABLE_PROCEDURES}.{COLUMN_PROCEDURES_ID} = {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_FKPROCEDURE}" +
                               $" WHERE accPract.{COLUMN_USER_ID} = {PARAM_USER_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_ID, user.Id);

                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            Appointment appointment = new Appointment();
                            appointment.Id = (int)sqlReader[0];
                            appointment.ClientId= (int)sqlReader[1];
                            appointment.PractitionerId = (int)sqlReader[2];
                            appointment.OfficeId = (int)sqlReader[3];
                            appointment.ProcedureId = (int)sqlReader[4];
                            appointment.TimeReserved = (DateTime)sqlReader[5];
                            appointment.TimeProcedure = (DateTime)sqlReader[6];
                            appointment.Confirmed = (bool)sqlReader[7];


                            appointments.Add(appointment);
                        }
                    }
                    sqlReader.Close();
                }
            }

            foreach (Appointment appointment in appointments)
            {
                appointment.Client = FindById(appointment.ClientId);
                appointment.Practitioner = FindById(appointment.PractitionerId);
                appointment.Office = FindOfficeById(appointment.OfficeId);
                appointment.Procedure = findProcedureById(appointment.ProcedureId);
            }
            return appointments;
        }
        public User FindById(int Id)
        {
            User user = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_user}.{COLUMN_USER_ID}, {TABLE_user}.{COLUMN_USER_USERNAME}, {TABLE_user}.{COLUMN_USER_EMAIL}, {TABLE_user}.{COLUMN_USER_NAME}, {TABLE_user}.{COLUMN_USER_LASTNAME}, {TABLE_user}.{COLUMN_USER_BIRTHDATE}, {TABLE_user}.{COLUMN_USER_DNI}, {TABLE_userStatus}.{COLUMN_USERSTATUS_BLOCKED}, {TABLE_userStatus}.{COLUMN_USERSTATUS_ATTEMPTS}" +
                                $" FROM {TABLE_user}" +
                                $" INNER JOIN {TABLE_userStatus} ON {TABLE_user}.{COLUMN_USER_ID} = {TABLE_userStatus}.{COLUMN_USERSTATUS_FK_ACCOUNT}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_ID} = {Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            user = new User(new object[] {(int) sqlReader[0],
                                                    (string) sqlReader[1],
                                                    (string) sqlReader[2],
                                                    (string) sqlReader[3],
                                                    (string) sqlReader[4],
                                                    (DateTime) sqlReader[5],
                                                    (int) sqlReader[6]});

                            user.IsBlocked = (bool)sqlReader[7];
                            user.Attempts = (int)sqlReader[8];
                        }
                    }
                    sqlConnection.Close();
                    sqlReader.Close();
                }
            }
            return user;
        }

        public Address FindOfficeById(int Id)
        {
            Address address = null;
            Province province = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_address}.{COLUMN_ADDRESS_ADDRESS1}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ADDRESS2}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ADDRESSNumber}," +
                                        $" {TABLE_provinces}.{COLUMN_PROVINCES_NAME}," +
                                        $" {TABLE_provinces}.{COLUMN_PROVINCES_ID}," +
                                        $" {TABLE_address}.{COLUMN_ADDRESS_ID}" +
                                $" FROM {TABLE_address}" +
                                $" INNER JOIN {TABLE_provinces}" +
                                $" ON {TABLE_provinces}.{COLUMN_PROVINCES_ID} = {TABLE_address}.{COLUMN_ADDRESS_FK_Province}" +
                                $" WHERE {TABLE_address}.{COLUMN_ADDRESS_ID} = {PARAM_ADDRESS_ID} ";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_ADDRESS_ID, Id);
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        address = new Address();
                        province = new Province();

                        while (sqlReader.Read())
                        {
                            address.Address1 = (string)sqlReader[0];
                            address.Address2 = (string)sqlReader[1];
                            address.AddressNumber = (int)sqlReader[2];
                            province.name = (string)sqlReader[3];
                            province.id = (int)sqlReader[4];
                            address.Id = (int)sqlReader[5];

                            address.Province = province;
                        }
                    }
                    sqlConnection.Close();
                    //sqlReader.Close();
                }
            }

            return address;
        }
        public Procedure findProcedureById(int id)
        {
            Procedure procedure = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PROCEDURES_ID}, {COLUMN_PROCEDURES_NAME}, {COLUMN_PROCEDURES_DESCRIPTION}, {COLUMN_PROCEDURES_COST}" +
                                $" FROM {TABLE_PROCEDURES}" +
                                $" WHERE {COLUMN_PROCEDURES_ID} = {PARAM_PROCEDURES_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROCEDURES_ID, id);

                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            procedure = new Procedure();
                            procedure.Id = (int)sqlReader[0];
                            procedure.Name = (string)sqlReader[1];
                            procedure.Desc = (string)sqlReader[2];
                            procedure.Price = (double)sqlReader[3];
                        }
                    }
                    sqlReader.Close();
                }
            }

            return procedure;
        }
        public bool confirmTurn(Appointment appointment)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string query = $"UPDATE {TABLE_APPOINTMENT}" +
                                $" SET {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_CONFIRMED} = 1" +
                                $" WHERE {TABLE_APPOINTMENT}.{COLUMN_APPOINTMENT_ID} = {PARAM_APPOINTMENT_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_APPOINTMENT_ID, appointment.Id);

                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
