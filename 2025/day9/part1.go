package day9

import (
	"fmt"
	"os"
	"regexp"
	"sort"
)

type Coord2D struct {
	x int
	y int
}

type PairArea struct {
	first  int
	second int
	area   int
}

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day9\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)

	var coords []Coord2D
	for _, line := range lines {
		var x, y int
		fmt.Sscanf(line, "%d,%d", &x, &y)
		coords = append(coords, Coord2D{x, y})
	}

	var areas []PairArea
	for i := 0; i < (len(coords) - 1); i++ {
		for j := i + 1; j < len(coords); j++ {
			areas = append(areas, PairArea{i, j, getArea(coords[i], coords[j])})
		}
	}

	sort.Slice(areas, func(i, j int) bool {
		return areas[i].area > areas[j].area
	})

	fmt.Println(areas[0].area)
}

func getArea(first Coord2D, second Coord2D) int {
	l := abs(first.x-second.x) + 1
	b := abs(first.y-second.y) + 1
	return l * b
}

func abs(num int) int {
	if num < 0 {
		return 0 - num
	}
	return num
}
