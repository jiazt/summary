// 方式1
function B() {}
function A() {}
B.prototype = new A();


// 方式2
function A() { }

function
    B() {

    A.call(
        this
    );

}


// 方式3

function
    B() { }

function
    A() { }

B.prototype =
    new
        A();


function
    B() {
    A.call(
        this
    );
}