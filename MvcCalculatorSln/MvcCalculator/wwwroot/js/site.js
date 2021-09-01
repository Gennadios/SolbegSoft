function AddValue(val) {
    if (document.getElementById("result").value == "0" && val != ",") {
        document.getElementById("result").value = ""
    }
    document.getElementById("result").value += val;
}

function Clear() {
    document.getElementById("result").value = null;
}