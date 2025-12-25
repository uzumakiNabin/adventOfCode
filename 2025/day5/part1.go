package day5

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
)

type Range struct {
	start int
	end   int
}

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day5\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n\r\n`)
	combinedInputs := re.Split(input, -1)

	re = regexp.MustCompile(`\r\n|\n|\r`)
	rangesStr := re.Split(combinedInputs[0], -1)
	ids := re.Split(combinedInputs[1], -1)
	var ranges []Range
	for _, rng := range rangesStr {
		var start, end int
		fmt.Sscanf(rng, "%d-%d", &start, &end)
		ranges = append(ranges, Range{start, end})
	}

	count := 0

	for _, id := range ids {
		idInt, err := strconv.Atoi(id)
		if err != nil {
			fmt.Println("Error Parsing Input", id)
			return
		}
		for _, rng := range ranges {
			if idInt >= rng.start && idInt <= rng.end {
				count++
				break
			}
		}
	}

	fmt.Println(count)
}
