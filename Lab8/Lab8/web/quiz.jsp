<%@ page import="domain.Question" %>
<%@ page import="java.util.List" %>
<%@ page import="domain.User" %><%--
  Created by IntelliJ IDEA.
  User: cosmi
  Date: 5/6/21
  Time: 3:00 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Quiz</title>
    <style>
        body{
            background-image: url("background.jpg");
        }
        form {
            margin-left: auto;
            margin-right: auto;
            width: 400px;
        }
        h2 {
            font-weight: bold;
        }
        button {background-color: #008CBA;
            height: 30px;
        }
    </style>
    <script type="text/javascript" src="js/ajax-utils.js"></script>
    <script src="js/jquery-2.0.3.js"></script>
</head>
<body>
<%
    User user = (User) session.getAttribute("user");
    if(user == null){
        response.sendRedirect("/bad_request.jsp");
    }
%>
<section id="questions">
</section>
<p><button id="next-btn" type="button">Next</button></p>
<script>
    function showQuestions(questions) {
        var content = "";
        for (let i = 0; i < questions.length; i++) {
            content += "<h4><b>" + questions[i]["question"] + "</b></h4>";
            content += "<input type = \"radio\" name = \"" + i + "\" value = \"1\">" + questions[i]["answer1"] + "<br>";
            content += "<input type = \"radio\" name = \"" + i + "\" value = \"2\">" + questions[i]["answer2"] + "<br>";
            content += "<input type = \"radio\" name = \"" + i + "\" value = \"3\">" + questions[i]["answer3"] + "<br>";
        }
        $("#questions").html(content);
    }
    function updateScore(score, questions) {
        for (let i = 0; i < questions.length; i++) {
            console.log(questions);
            var inputName = "\"" + i + "\"";
            var radioValue = $("input[name=" + inputName + "]:checked").val();
            if (parseInt(radioValue) === parseInt(questions[i]["correctAnswer"])) {
                score["right"]++;
            } else {
                score["wrong"]++;
            }
        }
    }
    $(document).ready(function(){
        var currentData = {page: 1, toGo: true};
        //loadQuestions(currentData);
        $.getJSON("/quiz",
            {action: "getQuestions", page: 0},
            function(data) {
                showQuestions(data["questions"]);
                currentData["questions"] = data["questions"];
                if (data["done"] === true){
                    currentData["toGo"] = false;
                }
            }
        );
        var score = {right: 0, wrong: 0};
        $("#next-btn").click(function() {
            updateScore(score, currentData["questions"], currentData);
            if(currentData["toGo"] === false) {
                //done(score);
                $.post(
                    "/quiz",
                    { action: 'done', right: score["right"], wrong: score["wrong"]},
                    () => location.href = '/web/result.jsp'
                );
            } else {
                //nextBunch(currentData);
                $.getJSON("/quiz",
                    {action: "getQuestions", page: currentData["page"]},
                    function(data){
                        if(data["done"] === false) {
                            showQuestions(data["questions"]);
                            currentData["questions"] = data["questions"];
                        } else {
                            showQuestions(data["questions"]);
                            currentData["toGo"] = false;
                            currentData["questions"] = data["questions"];
                        }
                    }
                );
                currentData["page"] = currentData["page"] + 1;
            }
        })
    });
</script>
</body>
</html>
