const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let instr = text.trim().split(/\r\n/);
  instr.forEach((ky) => {
    let [str, checksum] = [...ky.split("[")];
    checksum = checksum.replace("]", "");
    let section = str.substr(-3);
    let name = str.substr(0, str.length - 3);
    if (getChecksum(name) === checksum) {
      if (decrypt(name, section).includes("northpole")) {
        console.log(`Section id of ${decrypt(name, section)} is ${section}`);
      }
    }
  });
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

const shift = (num, amount) => {
  if (num + amount > 122) {
    return num + amount - 26;
  } else {
    return num + amount;
  }
};

const decrypt = (txt, num) => {
  const cypher = txt.split("-");
  const plain = [];
  const shiftAmnt = num % 26;
  cypher.forEach((word) => {
    let plainWord = "";
    for (let i = 0; i < word.length; i += 1) {
      plainWord = plainWord.concat(
        String.fromCharCode(shift(word[i].charCodeAt(0), shiftAmnt))
      );
    }
    plain.push(plainWord);
  });
  return plain.join(" ");
};
