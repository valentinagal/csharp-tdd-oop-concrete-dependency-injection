# Object-oriented Programming - Dependency Injection (concrete classes)

## Learning Objectives
- Use dependency injection to improve extensibility of a program
- Explain the drawbacks of creating instances of classes inside other classes

## Set up instructions
- Fork this repository and clone the forked version to your machine
- Open the project in Visual Studio

## Introduction

When a class uses an instance of another class, we call that dependency. When Class A uses a method that exists on Class B, Class A is dependent on Class B existing and actually providing the method being used. Class B is the dependency.

Consider the following pseudocode:

```C#
class Car {
    public void accelerate() {
        Engine engine = new Engine();
        engine.ignite();
        engine.injectFuel();
    }
}

class Program {
    public static void main() {
        Car car = new Car();
        car.accelerate();
        car.accelerate();
    }
}
```

Every time `car.accelerate()` is called, the car creates a new instance of the engine class, triggers the ignition, and then injects fuel to make it go. Imagine having to give your car a brand-new engine every time a traffic light turned green! The `Car` class is dependent on the `Engine` class.

We can make a simple improvement by moving the engine creation to the car's constructor so it only creates one instance to be used:

```C#
class Car {
    Engine engine;
    
    public Car() {
        this.engine = new Engine();
    }
    
    public void accelerate() {
        this.engine.ignite();
        this.engine.injectFuel();
    }
}
```

This is a step in the right direction. At least the car will only ever use one instance of an engine and not replace it every time it accelerates... but what if the engine breaks? What if we need to repair it? As it is right now, we would have to add a method to the car class to repair the engine:

```C#
class Car {
    Engine engine;
    
    public Car() {
        this.engine = new Engine();
    }
    
    public void accelerate() {
        this.engine.ignite();
        this.engine.injectFuel();
    }
    
    public void repairEngine() {
        this.engine = new Engine();
    }
}
```

This is quickly breaking one of the earlier rules of OOP: encapsulation. The car class is doing more than it should! This is where *Dependency Injection* can help. We can provide dependencies for classes to use to enable managing them better; we can *inject* dependencies into classes. To do this, we can use a class constructor in the same way we define method parameters:

```C#
class Engine {
    public void repair() {}
}

class Car {
    Engine engine;
    
    public Car(Engine engine) {
        this.engine = engine;
    }
    
    public void accelerate() {
        this.engine.ignite();
        this.engine.injectFuel();
    }
}
```

The Car class is still dependent on the Engine class, but it's a lot easier to manage that dependency now. We can provide the car with any instance of the engine class that we want to (it could have a 2 litre capacity, 1.5 litre, anything we like). Additionally, the car is no longer responsible for providing a method to repair the engine.

```C#
class Program {
    public static void main() {
        Engine engine = new Engine();
        Car car = new Car(engine);
        
        car.accelerate();
        car.accelerate();
        
        engine.repair();
        
        car.accelerate();
    }
}
```

## Exercise

In the `./tdd-oop-concrete-dependency-injection.CSharp.Main` directory are a number of classes. The `Computer` class has some dependencies which it is hard coding inside its methods. Your task is to refactor the Computer class to make the tests pass.

The tests are in the `./src/test/java/com/booleanuk/core` directory. Don't change them, but you can use them as a guide to inform your decisions.

When all the tests pass, the exercise is complete.

## Extension

Refactor the classes so that you are passing in instances of the Game class rather than instantiating them inside the Computer class modify any corresponding tests to make them work. Create a new branch for this.

Refactor the classes and any tests that use them so that they exhibit encapsulation and abstraction more fully.

## Next Steps

Now that you've practice dependency injection, apply this knowledge to your ongoing Bob's Bagels OOP exercise. You should have multiple classes working together in that exercise; any dependencies should be injected rather than hard coded. You can inject via constructors and via method parameters.
