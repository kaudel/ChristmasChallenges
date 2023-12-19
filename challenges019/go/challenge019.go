package main

import (
	"fmt"
	"sort"
)

func main() {
	//toys := []string{"ball", "doll", "car", "puzzle"}
	toys := []string{"pc", "xbox", "ps4", "switch", "nintendo"}
	positions := []int{8, 6, 5, 7, 9}
	fmt.Println(sortToys(toys, positions))

}

func sortToys(toys []string, positions []int) []string {
	//could not start in 0 position
	// always will be consecutive numbers
	// toys or positions not will be repeated
	//return an array with toys in the corresponding position

	//Fill map
	m := make(map[int]string)
	for x, s := range positions {
		m[s] = toys[x]
	}

	//Get Keys
	keys := make([]int, 0, len(m))
	for k := range m {
		keys = append(keys, k)
	}
	//order keys
	sort.Ints(keys)

	var toysOrderded []string

	for _, x := range keys {
		toysOrderded = append(toysOrderded, m[x])
		//toysOrderded[x] = m[x]
		//strings := append(toysOrderded, m[x])
	}

	return toysOrderded
}
