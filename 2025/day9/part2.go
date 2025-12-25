package day9

import (
	"fmt"
	"os"
	"regexp"
	"sort"
)

func Part2() {
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

	for _, area := range areas {
		if isAreaInside(coords, coords[area.first], coords[area.second]) {
			fmt.Println(area.area)
			break
		}
	}
}

func isAreaInside(coords []Coord2D, a Coord2D, c Coord2D) bool {
	b := Coord2D{a.x, c.y}
	d := Coord2D{c.x, a.y}
	fmt.Println("abcd", a, b, c, d)
	return isPointInside(coords, a) && isPointInside(coords, b) && isPointInside(coords, c) && isPointInside(coords, d)
}

func isPointInside(coords []Coord2D, p Coord2D) bool {
	res := false
	intersectionCount := 0
	for i, j := 0, 1; i < len(coords); i, j = i+1, (j+1)%len(coords) {
		a := coords[i]
		b := coords[j]
		// fmt.Println(a, b)
		// check if point in on line
		if (b.y-a.y)*(p.x-a.x) == (b.x-a.x)*(p.y-a.y) {
			res = true
			break
		}

		// ray casting

	}
	return res || intersectionCount%2 == 1
}
