function panel1() {
    var arr = [1, 2, [33, [55], 43], 20, 19];
    arr = arr.join(".").replace(/,/g, ".").split(".");
    console.log(arr);
}