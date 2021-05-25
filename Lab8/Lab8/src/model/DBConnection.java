package model;


import domain.Question;
import domain.Session;
import domain.User;
import org.postgresql.Driver;

import java.sql.*;
import java.util.ArrayList;

public class DBConnection {
    private String dbType;
    private String dbHost;
    private String dbPort;
    private String dbName;
    private String dbUser;
    private String dbPass;
    public DBConnection(){
        this.dbType = "postgresql";
        this.dbHost = "localhost";
        this.dbPort = "5432";
        this.dbName = "quizWeb";
        this.dbUser = "postgres";
        this.dbPass = "password";
    }

    private void loadDriver(){
        try {
             Class.forName("org.postgresql.Driver");
        }catch (ClassNotFoundException e){
            System.err.println("Driver can't be loaded!");
        }
    }

    private Connection dbConnection(){
        loadDriver();
        try{
            String url = "jdbc:" + this.dbType + "://" + this.dbHost + "/" + this.dbName + "?user=" + this.dbUser +
            "&password=" + this.dbPass;
            return DriverManager.getConnection(url);
        } catch (SQLException throwables) {
            System.err.println("Can't connect to DB");
        }
        return null;
    }

    public User auth(String user, String pass){
        ResultSet resultSet;
        User user1 = null;
        try(Connection connection = this.dbConnection()){
            assert connection != null;
            Statement statement = connection.createStatement();
            String sql = "SELECT * FROM users WHERE username='" + user + "' AND password='" + pass + "'";
            resultSet = statement.executeQuery(sql);
            if(resultSet.next()){
                user1 = new User(
                        resultSet.getInt("id"),
                        resultSet.getString("username"),
                        resultSet.getString("password"),
                        resultSet.getInt("best"));
            }
            resultSet.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return user1;
    }

    public Session getCurrentSession(int userId){
        ResultSet resultSet;
        Session session = null;
        try(Connection connection = this.dbConnection()){
            assert connection != null;
            Statement statement = connection.createStatement();
            String sql = "SELECT * FROM sessions WHERE sessions.userid='" + userId + "' and active = true";
            resultSet = statement.executeQuery(sql);
            if(resultSet.next()){
                session = new Session(
                        resultSet.getInt("id"),
                        resultSet.getInt("userId"),
                        resultSet.getInt("noQuestionsPerPage"),
                        resultSet.getInt("noTotalQuestions"),
                        resultSet.getBoolean("active"));
            }
            resultSet.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return session;
    }



    public ArrayList<Question> getAllQuestions(){
        ResultSet resultSet;
        ArrayList<Question> questions = new ArrayList<>();
        try(Connection connection = this.dbConnection()){
            assert connection != null;
            Statement statement = connection.createStatement();
            String sql = "SELECT * FROM question";
            resultSet = statement.executeQuery(sql);
            while(resultSet.next()){
                questions.add(new Question(
                        resultSet.getInt("id"),
                        resultSet.getString("question"),
                        resultSet.getString("answer1"),
                        resultSet.getString("answer2"),
                        resultSet.getString("answer3"),
                        resultSet.getInt("correct")));
            }
            resultSet.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return questions;
    }

    public int createSession(int userId, int questionsPerPage, int totalQuestions){
        try(Connection connection = dbConnection()){
            PreparedStatement statement = connection.prepareStatement("INSERT INTO sessions(userId, \"noQuestionsPerPage\", \"noTotalQuestions\", active) VALUES (?,?,?,?)", Statement.RETURN_GENERATED_KEYS);
            statement.setInt(1, userId);
            statement.setInt(2, questionsPerPage);
            statement.setInt(3, totalQuestions);
            statement.setBoolean(4, true);
            int rows = statement.executeUpdate();
            if (rows > 0 ){
                ResultSet resultSet = statement.getGeneratedKeys();
                if (resultSet.next()){
                    return resultSet.getInt(1);
                }else {
                    return -1;
                }
            }
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return -1;
    }

    public boolean closeSession(int sessionId){

        int result = 0;
        try(Connection connection = this.dbConnection()){
            assert connection != null;
            Statement statement = connection.createStatement();
            result = statement.executeUpdate("UPDATE sessions SET active = false WHERE id=" + sessionId);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return result > 0;
    }

    public boolean updateBest(int userId, int best){
        int result = 0;
        try(Connection connection = this.dbConnection()){
            assert connection != null;
            Statement statement = connection.createStatement();
            result = statement.executeUpdate("UPDATE users SET best= " + best + " WHERE id=" + userId);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return result > 0;
    }

}
