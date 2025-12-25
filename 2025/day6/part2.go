package day6

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func Part2() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day6\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)
	signs := lines[len(lines)-1]
	lines = lines[0:(len(lines) - 1)]
	var splitLines [][]string

	sliceIndex := 0
	prevSign := string(signs[0])
	for i, c := range signs {
		if i == 0 {
			continue
		}
		if string(c) != " " {
			var splitLine []string
			for _, line := range lines {
				splitLine = append(splitLine, string(line[sliceIndex:(i-1)]))
			}
			splitLine = append(splitLine, prevSign)
			splitLines = append(splitLines, splitLine)
			prevSign = string(c)
			sliceIndex = i
		}
	}
	var splitLine []string
	for _, line := range lines {
		splitLine = append(splitLine, string(line[sliceIndex:]))
	}
	splitLine = append(splitLine, prevSign)
	splitLines = append(splitLines, splitLine)

	total := 0

	for _, col := range splitLines {
		var a []string
		for i := range col[0] {
			var c string
			for j := 0; j < (len(col) - 1); j++ {
				c += string(col[j][i])
			}
			a = append(a, c)
		}

		b := make([]int, len(a))
		for l, f := range a {
			b[l], _ = strconv.Atoi(strings.TrimSpace(f))
		}

		total += performMath(b, string(col[len(col)-1]))
	}

	fmt.Println(total)
}
