$(function () {
    var info = $.connection.PersonHub;
    info.client.addNewInfo = function (key, value) {
        $('#info').append('<li><strong>' + htmlEncode(key) + 
    }
})

$(function () {
    // Reference the auto-generated proxy for the hub.  
    var info = $.connection.personHub;
    // Create a function that the hub can call back to display info.
    info.client.addNewInfo = function (key, value) {
        // Add the info to the page. 
        $('#info').append('<li><strong>' + htmlEncode(key)
            + '</strong>: ' + htmlEncode(value) + '</li>');
    };
    // Set initial focus to info input box.  
    $('#key').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#addinfo').click(function () {
            // Call the Add method on the hub. 
            chat.server.send($('#key').val(), $('#value').val());
            // Clear text box and reset focus for next comment. 
            $('#key').val('').focus();
            $('#value').val('')
        });
    });
});

function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}