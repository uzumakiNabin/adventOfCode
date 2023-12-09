const { MD5 } = require("./MD5");

const INPUT = "abbhdwsy";

let password = "";
const doorId = INPUT;
let num = 1;
while (true) {
  let hash = MD5(doorId + num);
  num += 1;
  if (hash.match(new RegExp("^[0]{5}"))) {
    password = password.concat(hash.charAt(5));
  }
  if (password.length >= 8) break;
}
console.log(`Password is ${password}`);
