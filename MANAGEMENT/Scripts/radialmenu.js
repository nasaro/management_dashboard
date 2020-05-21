$(document).ready(function(){
  function radialMenu() {
    $('.radial-nav').on('click', function(evt){
      evt.stopPropagation();    
      $('.nav, .item').removeClass('active');
      $(this).toggleClass('expanded');
      $(this).find('li').removeClass('selected');
    });
    
    $('.radial-nav li').not('.menu').click(function(evt){
      evt.stopPropagation();
      $(this).addClass('selected');
      $('.nav').addClass('active');
      $('.radial-nav').removeClass('expanded');
      getContent(this);
    });    

    function getContent(elem){
      $('#'+$(elem).attr('data-content')).addClass('active');
    }
  }
  radialMenu();
});