const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let screen = [];
  for (let i = 0; i < 6; i += 1) {
    if (screen[i] === undefined) screen.push([]);
    for (let j = 0; j < 50; j += 1) {
      screen[i][j] = 0;
    }
  }
  let instr = text.trim().split(/\r\n/);
  instr.forEach((ky) => {
    let rotAmnt = "";
    let instruction = ky.split(" ");
    if (instruction[0] === "rect") {
      let [y, x] = [...instruction[1].split("x")];
      for (let i = 0; i < x; i += 1) {
        for (let j = 0; j < y; j += 1) {
          screen[i][j] = 1;
        }
      }
    } else {
      if (instruction[1] === "row") {
        let y = instruction[2].split("=")[1];
        let row = screen[y];
        let temp = [];
        rotAmnt = +instruction[4];
        for (let i = 0; i < row.length; i += 1) {
          temp[(i + rotAmnt) % 50] = row[i];
        }
        screen[y] = temp;
      } else {
        let x = instruction[2].split("=")[1];
        let col = [];
        let temp = [];
        rotAmnt = +instruction[4];
        for (let i = 0; i < screen.length; i += 1) {
          col.push(screen[i][x]);
        }
        for (let i = 0; i < col.length; i += 1) {
          temp[(i + rotAmnt) % 6] = col[i];
        }
        for (let i = 0; i < screen.length; i += 1) {
          screen[i][x] = temp[i];
        }
      }
    }
  });
  console.log(
    screen
      .map((sc) => sc.join(""))
      .join("")
      .match(new RegExp("[1]", "g")).length
  );
});
