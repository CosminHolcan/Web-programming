package controller;

import domain.Session;
import domain.User;
import model.DBConnection;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class LoginController extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        String username = request.getParameter("username");
        String password = request.getParameter("password");

        DBConnection db = new DBConnection();
        User user = db.auth(username, password);
        if (user != null) {
            Session currentSession = db.getCurrentSession(user.getId());
            if (currentSession != null && currentSession.isActive()) {
                db.closeSession(db.getCurrentSession(user.getId()).getId());
            }
            request.getSession().setAttribute("user", user);
            response.sendRedirect("/web/home.jsp");
        } else {
            response.sendRedirect("/web/bad_request.jsp");
        }
    }
}
