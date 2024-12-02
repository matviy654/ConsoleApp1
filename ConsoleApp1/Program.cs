#include <iostream>
#include <stack>
#include <vector>
#include <string>
#include <typeinfo>

using namespace std;

void arithmeticOperations()
{
    int a;
    float b;
    cout << "Введіть ціле число (a): ";
    cin >> a;
    cout << "Введіть число з плаваючою точкою (b): ";
    cin >> b;

    cout << "Сума a + b: " << a + b << endl;
    cout << "Різниця a - b: " << a - b << endl;
    cout << "Множення a * b: " << a * b << endl;
    cout << "Цілочисельне ділення (int)b / a: " << static_cast<int>(b) / a << endl;

    cout << "Приведення типів виконується автоматично для арифметичних операцій: ціле число перетворюється в float.\n";
}

void charToAscii()
{
    char ch;
    cout << "Введіть символ: ";
    cin >> ch;
    cout << "ASCII-код символу: " << static_cast<int>(ch) << endl;

    int asciiCode;
    cout << "Введіть ASCII-код: ";
    cin >> asciiCode;
    cout << "Відповідний символ: " << static_cast<char>(asciiCode) << endl;

    string str;
    cout << "Введіть рядок: ";
    cin >> str;
    cout << "ASCII-коди символів: ";
    for (char c : str)
    {
        cout << static_cast<int>(c) << " ";
    }
    cout << endl;
}

void staticCastExample()
{
    int a;
    float b;
    cout << "Введіть ціле число (a): ";
    cin >> a;
    cout << "Введіть число з плаваючою точкою (b): ";
    cin >> b;

    cout << "a (float) + b: " << static_cast<float>(a) + b << endl;
    cout << "b (int) * a: " << static_cast<int>(b) * a << endl;
    cout << "a як символ: " << static_cast<char>(a) << endl;
}

void validateBrackets()
{
    string expression;
    cout << "Введіть вираз із дужками: ";
    cin >> expression;

    stack<char> brackets;
    for (char c : expression)
    {
        if (c == '(')
        {
            brackets.push(c);
        }
        else if (c == ')')
        {
            if (brackets.empty())
            {
                cout << "Invalid\n";
                return;
            }
            brackets.pop();
        }
    }
    cout << (brackets.empty() ? "Valid" : "Invalid") << endl;
}

class Shape
{
    public:
    virtual void draw() const = 0;
    virtual ~Shape() = default;
};

class Circle : public Shape {
public:
    void draw() const override {
        cout << "Drawing Circle\n";
    }
};

class Rectangle : public Shape
{
public:
    void draw() const override {
        cout << "Drawing Rectangle\n";
    }
};

void dynamicCastExample()
{
    vector<Shape*> shapes = { new Circle(), new Rectangle(), new Circle() };
    for (Shape* shape : shapes) {
    if (Circle * c = dynamic_cast<Circle*>(shape))
    {
        c->draw();
    }
    else if (Rectangle * r = dynamic_cast<Rectangle*>(shape))
    {
        r->draw();
    }
    else
    {
        cout << "Невірне приведення\n";
    }
}
for (Shape* shape : shapes)
{
    delete shape;
}
}

void modifyValue(const int* ptr)
{
    int* nonConstPtr = const_cast<int*>(ptr);
    *nonConstPtr = 200;
}

void constCastExample()
{
    const int value = 100;
    cout << "До зміни: " << value << endl;

    modifyValue(&value);
    cout << "Після зміни: " << value << endl;
}

int main()
{
    cout << "Завдання 1\n";
    arithmeticOperations();

    cout << "\nЗавдання 2\n";
    charToAscii();

    cout << "\nЗавдання 3\n";
    staticCastExample();

    cout << "\nЗавдання 4\n";
    validateBrackets();

    cout << "\nЗавдання 5\n";
    dynamicCastExample();

    cout << "\nЗавдання 6\n";
    constCastExample();

    return 0;
}
