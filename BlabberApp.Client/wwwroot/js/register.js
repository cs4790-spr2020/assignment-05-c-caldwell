$("#submit").click(function(){
    var re = new RegExp("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$");
    var emailAddress = $("#emailaddress").val()
    var passed = re.test(emailAddress)
    console.log(passed)
    if(passed){
        $("#form").submit()
    }
})