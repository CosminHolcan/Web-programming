$(document).ready(function() {     

$('#tabs li a:not(:first)').addClass('inactive');
$('.container').hide();
$('.container:first').show();

$('#tabs li').css({'float':'left', 'list-style':'none'});

$('#tabs li a:first').css('background','#6066F8');

$('#tabs li a').css({'cursor':'pointer', 'font-family':'Arial, Helvetica, sans-serif', 'font-size':'18px',
	'font-weight':'bold', 'color':'white', 'border-left':'2px gray solid', 'border-right':'2px gray solid'});
$('#tabs li a').css({ 'padding-top': '15px','padding-left': '12px','padding-right': '12px','padding-bottom': '15px','display':'block' });

$('#tabs li a.inactive').css('background', '#070A5C');

$('.container').css({
	'clear':'both', 'width':'100%', 
    'padding-top': '20px','padding-left': '30px'});

$('#tabs li a').hover(function() 
	{ 
		$(this).css('color', '#E5F211');
	}, function() 
	{
		$(this).css('color', 'white');
	});
    
$('#tabs li a').click(function(){
    var t = $(this).attr('id');
  if($(this).hasClass('inactive')){
  	$('#tabs li a').css({'background': '#070A5C'});
    $('#tabs li a').addClass('inactive');           
    $(this).removeClass('inactive');
    $(this).css({'color':'#E5F211','background': '#6066F8'});
    
    $('.container').hide();
    $('#'+ t + 'C').fadeIn('slow');
 }
});

});
