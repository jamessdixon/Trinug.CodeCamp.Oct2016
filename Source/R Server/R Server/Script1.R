
head(mtcars)
summary(mtcars)

model <- lm(mtcars$mpg ~ mtcars$wt)
summary(model)
