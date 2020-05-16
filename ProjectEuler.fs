﻿open System
open System.Numerics

module EulerOne = 

    let sumList list = List.reduce (+) list

    let multipleOf factor multiple = multiple % factor = 0

    let mulipleOfThreeOrFive element = 
            multipleOf 3 element || multipleOf 5 element

    let filterAndAdd listToFilter =
        listToFilter 
        |> List.filter mulipleOfThreeOrFive
        |> sumList 


module EulerTwo =

        let sumList (list:List<BigInteger>) :BigInteger = List.sum list

        // generate an infinite Fibonacci sequence
        // from: https://stackoverflow.com/questions/2845744/generating-fibonacci-series-in-f
        let fibSeq =    
            let rec fibseq n1 n2 = // recursive fibseq takes 2 params
                seq { let n0 = n1 + n2 // define sequence and calculate start
                      yield n0 // yield start
                      yield! fibseq n0 n1 } // merge with seq generated by fibseq
            seq { yield 1I ; yield 1I ; yield! (fibseq 1I 1I) } // return seq whose t3 is fibseq(t1, t2)

           
        //  filter for evens, take the first limit numbers in the sequence, and convert to a list
        let fibGen (limit:int) = 
                fibSeq 
                |> Seq.filter (fun x -> (x % BigInteger(2)) = BigInteger(0))
                |> Seq.takeWhile (fun x -> (x <= BigInteger(limit)))
                |> Seq.toList

        let fibSum limit = 
                fibGen limit
                |> sumList


[<EntryPoint>]
let main argv =
  printfn "Euler 1: %i" (EulerOne.filterAndAdd [1..999])
  printfn "Euler 2: %A" (EulerTwo.fibSum 4000000)
  0