package databaseConnection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;
import java.util.TimeZone;

public class DbConnectionHelper {

	protected static String connectionURL = "jdbc:h2:mem:november2026";
	protected static String username = "sa";
	protected static String password = "";

	public static Connection createConnection() throws SQLException {

		Connection result = null;

		TimeZone timeZone = TimeZone.getTimeZone("GMT+1:00");
		TimeZone.setDefault(timeZone);

		Properties connectionProps = new Properties();
		connectionProps.put("user", username);
		connectionProps.put("password", password);
		connectionProps.put("serverTimezone", "UTC");

		result = DriverManager.getConnection(connectionURL, connectionProps);

		return result;

	}

}
