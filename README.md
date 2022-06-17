**Problem :**

Consider building a floor out of 2 1 and 3 1 floorboards (length  width dimensions).  For aesthetic reasons, the end of the boards should not line up.
For example, the following 9 3 floor is not acceptable due to the alignment shown in red:
 
There are eight ways of forming an acceptable 9 3 floor, expressed as F(9,3) = 8.
Calculate F(32,10).
![image](https://user-images.githubusercontent.com/68649744/174351826-3c7049a7-2e8a-4921-9b9d-15696b05b23f.png)


**Solution Approach **

**Assumptions made:**
 1) Evaluation of first two floors should be sufficient since first floor value 
    can be replicated into all remaining odd floors and same logic is applicable in case of 2nd & even floors.  
 2) Considering two board sizes 2x1 and 3x1. In case no of the pattern matches, by default there will always be two possible layouts
 * i.e. 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
        3,2,2,2,2,2,2,2,2,2,2,2,2,2,3       
    and oppossible of it.
 3) considering board sizes (2x1 and 3x1) , floor size must be minimum 5 otherwise pattern count will be 0.
 
 
 **Output**
  
 In case of Floor Max size as 9 and total no of floors as 3 i.e f(9,3) , value is appearing as 6.
  **Option 1**
 2,2,2,3
 3,2,2,2
 
 **Option 2**
 3,2,2,2
 2,2,2,3
 
 **Option 3**
 2,2,3,2
 3,3,3
  
 **Option 4**
 2,2,3,2
 3,3,3
 
 **Option 5**
 2,3,2,2
 3,3,3,
 
 **Option 6**
 3,3,3
 2,3,2,2
 
 
 In case of Floor Max size as 32 and total no of floors as 10 i.e f(32,10) , value is appearing as 2.
 
 **Option 1**
 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
 3,2,2,2,2,2,2,2,2,2,2,2,2,2,3
 
 **Option 2**
 3,2,2,2,2,2,2,2,2,2,2,2,2,2,3
 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
