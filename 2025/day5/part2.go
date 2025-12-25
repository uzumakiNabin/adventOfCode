package day5

import (
	"fmt"
	"os"
	"regexp"
	"sort"
)

func Part2() {
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
	var ranges []Range
	for _, rng := range rangesStr {
		var start, end int
		fmt.Sscanf(rng, "%d-%d", &start, &end)
		ranges = append(ranges, Range{start, end})
	}

	sort.Slice(ranges, func(i, j int) bool {
		return ranges[i].start < ranges[j].start
	})

	count := 0
	currRange := ranges[0]
	for _, nextRange := range ranges {
		if nextRange.start == currRange.start {
			if nextRange.end > currRange.end {
				currRange.end = nextRange.end
			}
		} else {
			if nextRange.start > currRange.end {
				count += (currRange.end - currRange.start + 1)
				currRange = nextRange
			} else if nextRange.end > currRange.end {
				currRange.end = nextRange.end
			}
		}
	}
	count += (currRange.end - currRange.start + 1)

	fmt.Println(count)
}
