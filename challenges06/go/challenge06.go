package main

import "fmt"

func main() {

	createCube(8)
}

func createCube(size int) {
	sizeIterate := size - 1

	fmt.Println()
	//for to print every layer
	for k := 0; k < size; k++ {
		var faceB = ""
		var faceA = "/\\"
		var space = ""

		//spaces outside of cube
		for x := sizeIterate; x > 0; x-- {
			space = space + " "
		}
		sizeIterate--

		//faceA
		for y := 0; y < k; y++ {
			faceA = faceA + "/\\"
		}

		//faceB
		for y := 0; y < size; y++ {
			faceB = faceB + "_\\"
		}

		fmt.Print(space + faceA + faceB)
		fmt.Println()
	}

	sizeIterate = size - 1
	for k := 0; k < size; k++ {
		var faceB = ""
		var faceA = "\\/"
		var space = ""

		//spaces outside of cube
		if k > 0 {
			for x := 1; x <= k; x++ {
				space = space + " "
			}
		}

		//faceA
		for x := 0; x < sizeIterate; x++ {
			faceA = faceA + "\\/"
		}
		sizeIterate--

		//faceB
		for x := 0; x < size; x++ {
			faceB = faceB + "_/"
		}
		fmt.Print(space + faceA + faceB)
		fmt.Println()
	}
}
