Portfolio web.

This project requires that the connection string be in "User Secrets" of the development computer. Your SQL server needs to have a 
connection string named <ConnString> as a secret in the computer or container where it is running. This is a security measure to 
prevent the disclosure of data server information.  It also makes the time required to have the code running among different 
developers to be significantly reduced because it will read the data source from each development computer as it is set for each 
one.

#The connection string was finaly moved to run in an environment variable when the container is instantiated.  The connection string name is
  ConnString  
  

