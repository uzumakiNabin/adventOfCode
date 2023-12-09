const { MD5 } = require("./MD5");

const INPUT = "abbhdwsy";

const replaceStringAt = (str, ind, ch) => {
  return (
    str.substr(0, ind) +
    ch +
    (ind === str.length - 1 ? "" : str.substr(ind - str.length + 1))
  );
};

let password = "@@@@@@@@";
let count = 0;
const doorId = INPUT;
let num = 1;
while (true) {
  let hash = MD5(doorId + num);
  num += 1;
  if (hash.match(new RegExp("^[0]{5}"))) {
    let pos = +hash.charAt(5);
    if (pos <= 7 && pos >= 0 && password.charAt(pos) === "@") {
      password = replaceStringAt(password, pos, hash.charAt(6));
      count += 1;
    }
  }
  if (count >= 8) break;
}
console.log(`Password is ${password}`);
