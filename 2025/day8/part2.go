package day8

import (
	"aoc2025/utils"
	"fmt"
	"os"
	"regexp"
	"slices"
	"sort"
)

func Part2() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day8\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)

	var coords []Coord3D
	for _, line := range lines {
		var x, y, z int
		fmt.Sscanf(line, "%d,%d,%d", &x, &y, &z)
		coords = append(coords, Coord3D{x, y, z})
	}

	var distances []PairDist
	for i := 0; i < (len(coords) - 1); i++ {
		for j := i + 1; j < len(coords); j++ {
			distances = append(distances, PairDist{i, j, get3dDist(coords[i], coords[j])})
		}
	}

	sort.Slice(distances, func(i, j int) bool {
		return distances[i].dist < distances[j].dist
	})

	var circuits [][]int
	i := 0
	for {
		curr := distances[i]
		i++
		var circuitWithFirst, circuitWithSecond []int
		circuitWithFirstIdx := -1
		circuitWithSecondIdx := -1
		for j, c := range circuits {
			if slices.Index(c, curr.first) > -1 {
				circuitWithFirst = utils.DeepCopy(c)
				circuitWithFirstIdx = j
			}
			if slices.Index(c, curr.second) > -1 {
				circuitWithSecond = utils.DeepCopy(c)
				circuitWithSecondIdx = j
			}
		}
		if circuitWithFirstIdx == -1 && circuitWithSecondIdx == -1 {
			circuits = append(circuits, []int{curr.first, curr.second})
		} else if circuitWithFirstIdx == -1 && circuitWithSecondIdx > -1 {
			circuitWithSecond = utils.InsertUniqueIntoSlice(circuitWithSecond, curr.first)
			circuits = utils.RemoveIndexFromSlice(circuits, circuitWithSecondIdx)
			circuits = append(circuits, circuitWithSecond)
		} else if circuitWithFirstIdx > -1 && circuitWithSecondIdx == -1 {
			circuitWithFirst = utils.InsertUniqueIntoSlice(circuitWithFirst, curr.second)
			circuits = utils.RemoveIndexFromSlice(circuits, circuitWithFirstIdx)
			circuits = append(circuits, circuitWithFirst)
		} else {
			if circuitWithFirstIdx != circuitWithSecondIdx {
				circuitWithFirst = append(circuitWithFirst, circuitWithSecond...)
				if circuitWithFirstIdx > circuitWithSecondIdx {
					circuits = utils.RemoveIndexFromSlice(circuits, circuitWithFirstIdx)
					circuits = utils.RemoveIndexFromSlice(circuits, circuitWithSecondIdx)
				} else {
					circuits = utils.RemoveIndexFromSlice(circuits, circuitWithSecondIdx)
					circuits = utils.RemoveIndexFromSlice(circuits, circuitWithFirstIdx)
				}
				circuits = append(circuits, circuitWithFirst)
			}
		}
		if len(circuits[0]) == len(coords) {
			res := coords[curr.first].x * coords[curr.second].x
			fmt.Println(res)
			break
		}
	}
}
