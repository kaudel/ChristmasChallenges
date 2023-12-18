package main

import (
	"fmt"
	"sort"
)

type Box struct {
	Length int
	Width  int
	Height int
}

func main() {

	/*	boxesList := []Box{
		{
			Length: 1, Width: 1, Height: 1,
		},
		{
			Length: 3, Width: 3, Height: 3,
		},
		{
			Length: 2, Width: 3, Height: 2,
		},
	}*/

	boxesList := []Box{
		{
			Length: 1, Width: 1, Height: 1,
		},
		{
			Length: 5, Width: 1, Height: 5,
		},
		{
			Length: 2, Width: 2, Height: 2,
		},
		{
			Length: 3, Width: 4, Height: 3,
		},
	}

	fmt.Println("Boxes fits?", fitsInOneBox(boxesList))
}

func fitsInOneBox(boxes []Box) bool {

	// We need to know if all the boxs fits each other
	//first order all the boxes
	sort.SliceStable(boxes, func(i, j int) bool {
		return boxes[i].Length < boxes[j].Length
	})
	fmt.Println("Boxes ordered:", boxes)

	isLengthFits := true
	for x := 0; x < (len(boxes) - 1); x++ {
		if boxes[x].Length >= boxes[x+1].Length {
			isLengthFits = false
		}
	}
	fmt.Println("The boxes In length fits?", isLengthFits)

	isWidthFits := true
	for x := 0; x < (len(boxes) - 1); x++ {
		if boxes[x].Width >= boxes[x+1].Width {
			isWidthFits = false
		}
	}
	fmt.Println("The boxes in Width fits? ", isWidthFits)

	isHeightFits := true
	for x := 0; x < (len(boxes) - 1); x++ {
		if boxes[x].Height >= boxes[x+1].Height {
			isHeightFits = false
		}
	}
	fmt.Println("The boxes in Height fits? ", isHeightFits)

	return isHeightFits && isWidthFits && isLengthFits
}
