const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let result = [];
  let instr = text.trim().split(/\r\n/);
  instr.forEach((ky) => {
    for (let i = 0; i < ky.length; i += 1) {
      if (result[i] === undefined) {
        result.push([]);
      }
      if (result[i].findIndex((r) => r.letter === ky[i]) > -1) {
        result[i] = result[i].map((rs) => {
          if (rs.letter === ky[i]) {
            return { letter: rs.letter, count: rs.count + 1 };
          } else {
            return rs;
          }
        });
      } else {
        result[i].push({ letter: ky[i], count: 1 });
      }
    }
  });
  result = result
    .map((rs) => {
      let max = rs[0];
      rs.forEach((r) => {
        if (r.count > max.count) {
          max = r;
        }
      });
      return max;
    })
    .map((rs) => rs.letter);
  console.log(`Corrected version is ${result.join("")}`);
});
