package domain;

public class Session {
    private int id;
    private int userId;
    private int noQuestionsPerPage;
    private int noTotalQuestions;
    private boolean active;

    public Session(int id, int userId, int noQuestionsPerPage, int noTotalQuestions, boolean active) {
        this.id = id;
        this.userId = userId;
        this.noQuestionsPerPage = noQuestionsPerPage;
        this.noTotalQuestions = noTotalQuestions;
        this.active = active;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public int getNoQuestionsPerPage() {
        return noQuestionsPerPage;
    }

    public void setNoQuestionsPerPage(int noQuestionsPerPage) {
        this.noQuestionsPerPage = noQuestionsPerPage;
    }

    public int getNoTotalQuestions() {
        return noTotalQuestions;
    }

    public void setNoTotalQuestions(int noTotalQuestions) {
        this.noTotalQuestions = noTotalQuestions;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    @Override
    public String toString() {
        return "Session{" +
                "id=" + id +
                ", userId=" + userId +
                ", noQuestionsPerPage=" + noQuestionsPerPage +
                ", noTotalQuestions=" + noTotalQuestions +
                ", active=" + active +
                '}';
    }
}
