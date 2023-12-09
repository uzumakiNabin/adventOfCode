const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let keypad = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
  ];
  const add = (i) => {
    return i + 1 > 2 ? 2 : i + 1;
  };
  const subtr = (i) => {
    return i - 1 < 0 ? 0 : i - 1;
  };
  let x = 1,
    y = 1,
    password = "";
  let instr = text.trim().split(/\r\n/);
  const testt = instr.map((i) => i.substring(0, 5));
  instr.forEach((ky) => {
    for (let i = 0; i < ky.length; i++) {
      switch (ky[i]) {
        case "U":
          x = subtr(x);
          break;
        case "D":
          x = add(x);
          break;
        case "L":
          y = subtr(y);
          break;
        case "R":
          y = add(y);
          break;
        default:
          break;
      }
    }
    password = password.concat(keypad[x][y]);
  });
  console.log(`password is ${password}`);
});
