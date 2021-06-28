# Zonda Demo

## BasicLoopRunner

Count 10:  

```bash
Execution Summary: ZondaDemo.BasicLoopRunner, PASS

* Max WIP:
  - ALL:      1
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  13824
  - Context Switch Count: 30

* Waiting (Lead) Time:
  - Time To First Task Completed: 1492.6732 msec
  - Time To Last Task Completed:  14571.0978 msec
  - Total Waiting Time: 80255.1857 / msec, Average Waiting Time: 8025.51857

* Execute Count:
  - Total:   10
  - Success: 10
  - Failure: 0
  - Complete Step #1: 10
  - Complete Step #2: 10
  - Complete Step #3: 10
```


Count 100:  

```bash
Execution Summary: ZondaDemo.BasicLoopRunner, PASS

* Max WIP:
  - ALL:      1
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  13824
  - Context Switch Count: 300

* Waiting (Lead) Time:
  - Time To First Task Completed: 1503.9596 msec
  - Time To Last Task Completed:  145503.0479 msec
  - Total Waiting Time: 7347370.586 / msec, Average Waiting Time: 73473.70586

* Execute Count:
  - Total:   100
  - Success: 100
  - Failure: 0
  - Complete Step #1: 100
  - Complete Step #2: 100
  - Complete Step #3: 100
```

## BasicLoopStepLevelRunner

Count 10:  

```bash
Execution Summary: ZondaDemo.BasicLoopStepLevelRunner, PASS

* Max WIP:
  - ALL:      10
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  22912
  - Context Switch Count: 3

* Waiting (Lead) Time:
  - Time To First Task Completed: 10663.5626 msec
  - Time To Last Task Completed:  14599.9146 msec
  - Total Waiting Time: 126334.0103 / msec, Average Waiting Time: 12633.401029999999

* Execute Count:
  - Total:   10
  - Success: 10
  - Failure: 0
  - Complete Step #1: 10
  - Complete Step #2: 10
  - Complete Step #3: 10
```

Count 100:

```bash
Execution Summary: ZondaDemo.BasicLoopStepLevelRunner, PASS

* Max WIP:
  - ALL:      100
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  107008
  - Context Switch Count: 3

* Waiting (Lead) Time:
  - Time To First Task Completed: 102051.1727 msec
  - Time To Last Task Completed:  145347.1196 msec
  - Total Waiting Time: 12370226.2722 / msec, Average Waiting Time: 123702.262722

* Execute Count:
  - Total:   100
  - Success: 100
  - Failure: 0
  - Complete Step #1: 100
  - Complete Step #2: 100
  - Complete Step #3: 100
```

## PipelineRunner

Count 10:  

```bash
Execution Summary: ZondaDemo.PipelineRunner, PASS

* Max WIP:
  - ALL:      1
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  13824
  - Context Switch Count: 30

* Waiting (Lead) Time:
  - Time To First Task Completed: 1525.169 msec
  - Time To Last Task Completed:  14573.8283 msec
  - Total Waiting Time: 80458.8773 / msec, Average Waiting Time: 8045.8877299999995

* Execute Count:
  - Total:   10
  - Success: 10
  - Failure: 0
  - Complete Step #1: 10
  - Complete Step #2: 10
  - Complete Step #3: 10
```

Count 100: 

```bash
Execution Summary: ZondaDemo.PipelineRunner, PASS

* Max WIP:
  - ALL:      1
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  13824
  - Context Switch Count: 300

* Waiting (Lead) Time:
  - Time To First Task Completed: 1529.3371 msec
  - Time To Last Task Completed:  145408.9461 msec
  - Total Waiting Time: 7347302.0928 / msec, Average Waiting Time: 73473.020928

* Execute Count:
  - Total:   100
  - Success: 100
  - Failure: 0
  - Complete Step #1: 100
  - Complete Step #2: 100
  - Complete Step #3: 100
```

## PipelineQueueRunner

Count 10:  

```bash
Execution Summary: ZondaDemo.PipelineQueueRunner, PASS

* Max WIP:
  - ALL:      2
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  15232
  - Context Switch Count: 3

* Waiting (Lead) Time:
  - Time To First Task Completed: 1646.2279 msec
  - Time To Last Task Completed:  9508.7596 msec
  - Total Waiting Time: 55786.7744 / msec, Average Waiting Time: 5578.67744

* Execute Count:
  - Total:   10
  - Success: 10
  - Failure: 0
  - Complete Step #1: 10
  - Complete Step #2: 10
  - Complete Step #3: 10
```

Count 100:  

```bash
Execution Summary: ZondaDemo.PipelineQueueRunner, PASS

* Max WIP:
  - ALL:      2
  - Step #1:  1
  - Step #2:  1
  - Step #3:  1

* Used Resources:
  - Memory Usage (Peak):  15232
  - Context Switch Count: 3

* Waiting (Lead) Time:
  - Time To First Task Completed: 1675.0295 msec
  - Time To Last Task Completed:  88714.5476 msec
  - Total Waiting Time: 4529909.6901 / msec, Average Waiting Time: 45299.096901000004

* Execute Count:
  - Total:   100
  - Success: 100
  - Failure: 0
  - Complete Step #1: 100
  - Complete Step #2: 100
  - Complete Step #3: 100
```

## PipelineTreadQueueRunner

Count 10:  

```bash
Execution Summary: ZondaDemo.PipelineTreadQueueRunner, PASS

* Max WIP:
  - ALL:      10
  - Step #1:  5
  - Step #2:  3
  - Step #3:  3

* Used Resources:
  - Memory Usage (Peak):  26240
  - Context Switch Count: 11

* Waiting (Lead) Time:
  - Time To First Task Completed: 1727.6087 msec
  - Time To Last Task Completed:  3048.8735 msec
  - Total Waiting Time: 23473.5365 / msec, Average Waiting Time: 2347.35365

* Execute Count:
  - Total:   10
  - Success: 10
  - Failure: 0
  - Complete Step #1: 10
  - Complete Step #2: 10
  - Complete Step #3: 10
```

Count 100:  

```bash
Execution Summary: ZondaDemo.PipelineTreadQueueRunner, PASS

* Max WIP:
  - ALL:      12
  - Step #1:  5
  - Step #2:  3
  - Step #3:  3

* Used Resources:
  - Memory Usage (Peak):  28288
  - Context Switch Count: 11

* Waiting (Lead) Time:
  - Time To First Task Completed: 1931.9215 msec
  - Time To Last Task Completed:  19033.5336 msec
  - Total Waiting Time: 961987.7754 / msec, Average Waiting Time: 9619.877754000001

* Execute Count:
  - Total:   100
  - Success: 100
  - Failure: 0
  - Complete Step #1: 100
  - Complete Step #2: 100
  - Complete Step #3: 100
```