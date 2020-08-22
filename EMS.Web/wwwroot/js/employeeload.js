"use strict";

// https://www.zealousweb.com/signalr-to-send-real-time-notifications-with-asp-net-core/

var connection = new signalR.HubConnectionBuilder().withUrl("/EmployeeHub").build();

console.log("Connection created sucessfully.");


connection.on("sendToUser", (employee) => {

    var newRowContent = "<tr><td>" + employee.name + "</td><td>" + employee.email + "</td>";

    newRowContent = newRowContent + "<td><a href=" + url + "/" + employee.employeeId + ">Edit</a> | <a href=" + url + "/" + employee.employeeId + ">Delete</a> | <a href=" + url + "/" + employee.employeeId + ">View</a></td></tr>";

    $("#employeeList tbody").append(newRowContent);

});

connection.start().catch(function (err) {
    console.log(err.toString());

    return console.error(err.toString());
});


function GetEmployees() {

    //debugger;
    try {

        $.ajax({
            type: "GET",
            url: "/Employee/EmployeeList",
            //data: '{pageIndex: ' + pageIndex + '}',
            //contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response);
            },
            error: function (response) {
                alert(response);
            }
        });
    } catch (e) {

        alert("Error")
        alert(e.message);
    }
}


function OnSuccess(response) {

    for (var i = 0; i < response.length; i++) {

        var newRowContent = "<tr><td>" + response[i].name + "</td><td>" + response[i].email + "</td>";

        newRowContent = newRowContent + "<td><a href=" + url + "/" + response[i].employeeId + ">Edit</a> | <a href=" + url + "/" + response[i].employeeId + ">Delete</a> | <a href=" + url + "/" + response[i].employeeId + ">View</a></td></tr>";

        $("#employeeList tbody").append(newRowContent);
    }
};