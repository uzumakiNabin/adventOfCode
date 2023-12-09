const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let count = 0;
  let instr = text.trim().split(/\r\n/);
  instr.forEach((ky) => {
    let sides = ky
      .trim()
      .split(/\s+/)
      .map((sd) => +sd);
    if (is_possible(sides)) {
      count += 1;
    }
  });
  console.log(`${count} triangles are valid.`);
});

const is_possible = (tri) =>
  tri[0] + tri[1] > tri[2] &&
  tri[1] + tri[2] > tri[0] &&
  tri[2] + tri[0] > tri[1];
