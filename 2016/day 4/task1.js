const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let total = 0;
  let instr = text.trim().split(/\r\n/);
  instr.forEach((ky) => {
    let [str, checksum] = [...ky.split("[")];
    checksum = checksum.replace("]", "");
    let section = str.substr(-3);
    let name = str.substr(0, str.length - 3);
    if (getChecksum(name) === checksum) {
      total += +section;
    }
  });
  console.log(`Sum of the sector IDs of the real rooms is ${total}.`);
});

const getChecksum = (txt) => {
  let name = txt.replaceAll("-", "");
  let nameSet = new Set(name.split("").sort());
  let countList = [];
  let result = "";
  for (const el of nameSet) {
    let count = name.match(new RegExp(el, "g")).length;
    countList.push({ letter: el, count: count });
  }
  countList.sort((a, b) => b.count - a.count);
  countList.forEach((cnt, index) => {
    if (index < 5) {
      result = result.concat(cnt.letter);
    }
  });
  return result;
};
