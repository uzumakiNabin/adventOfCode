package day4

import (
	"fmt"
	"os"
	"regexp"
)

func Part2() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day4\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	rows := re.Split(input, -1)
	ROLL := "@"
	total := 0
	newRows := rows

calculate:
	count := 0
	rows = newRows
	for y, row := range rows {
		for x, item := range row {
			if string(item) != ROLL {
				continue
			}
			adjCount := 0
			if y > 0 && x > 0 && string(string(rows[y-1])[x-1]) == ROLL {
				adjCount++
			}
			if y > 0 && string(string(rows[y-1])[x]) == ROLL {
				adjCount++
			}
			if y > 0 && x < len(row)-1 && string(string(rows[y-1])[x+1]) == ROLL {
				adjCount++
			}
			if x < len(row)-1 && string(string(rows[y])[x+1]) == ROLL {
				adjCount++
			}
			if x < len(row)-1 && y < len(rows)-1 && string(string(rows[y+1])[x+1]) == ROLL {
				adjCount++
			}
			if y < len(rows)-1 && string(string(rows[y+1])[x]) == ROLL {
				adjCount++
			}
			if y < len(rows)-1 && x > 0 && string(string(rows[y+1])[x-1]) == ROLL {
				adjCount++
			}
			if x > 0 && string(string(rows[y])[x-1]) == ROLL {
				adjCount++
			}
			if adjCount < 4 {
				count++
				if x == 0 {
					row = "." + row[1:]
				} else if x == (len(row) - 1) {
					row = row[0:(len(row)-1)] + "."
				} else {
					row = row[0:x] + "." + row[x+1:]
				}
				newRows[y] = row
			}
		}
	}
	total += count
	if count > 0 {
		goto calculate
	}
	fmt.Println(total)
}
