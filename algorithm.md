``` javascript
//js数组拍平
var arr = [1,2,[33,43],20,19];
arr.join(".").replace(/,/g,".").split("."); 

//判断回文字符串
return input.split('').reverse().join('') === input

//简单实现数据双向绑定
const data = {};
const input = document.getElementById('input');
Object.defineProperty(data, 'text', {
    set(value) {
        input.value = value;
        this.value = value;
    }
});
input.onChange = function(e) {
    data.text = e.target.value;
}

//使得该对象为单例，并对localStorage进行封装设置值setItem(key,value)和getItem(key)
var instance = null;

class Storage {
    static getInstance() {
        if(!instance) {
            instance = new Storage();
        }
        return instance;
  }
  setItem = (key, value) => localStorage.setItem(key, value),
  getItem = key => localStorage.getItem(key)
}
//手写实现promise
//https://segmentfault.com/a/1190000013396601

//继承
// 方式1
function A(){}
function B(){}
B.prototype = new A();

// 方式2
function A(){}
function B(){
    A.call(this);
}

```