function buttonClick() {
  var author = $("#author").val();
  var genre = $("#genre").val();

           $.ajax({
                   url: "browse-books.php",
                   type: "GET",
                   data: { author:author,  genre:genre},
                   success:function (result) {
                      $('#tbodyTable').html(result);
                   }
               })
}

$(document).ready(function () {
       $('#submitButton').click(buttonClick);
       $('#submitButton').trigger('click');
    });

