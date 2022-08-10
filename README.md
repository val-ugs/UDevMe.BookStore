# BookStore

## Клиент-серверное приложение - магазин книг

Книга - это объект, состоящий из следующих полей:
<ol>
	<li>Id</li>
	<li>автор</li>
	<li>название</li>
	<li>год издания</li>
</ol>

Описание:
<ol>
  <li>Слой с данными - API с MSS SQL Server</li>

  <li>UI:
    <ol type="a">
      <li>
        Сайт на ASP.NET (Blazor)
        <ul>
          <li>
            страница с отображением списка книг, возможностью сортировать список по любому из параметров
          </li>
          <li>
            кнопка "купить": убирает одну книгу из списка отображаемых
          </li>
        </ul>
      </li>
      <li>
        Консольный режим
        </br>
        Две команды: get и buy
        </br>
        <ul>
          <li>
            get = возвращает полный список книг, отсортированных по Id по умолчанию
            </br>
            Флаги:
            <ul type="circle">
              <li>
                --title=%% вернуть книгу(и), если указанная подстрока встречается в названии, если таких книг нет, написать сообщение об отсутствии;
              </li>
              <li>
                --author=%% вернуть книгу(и) только с этим автором, если такой книги нет, написать сообщение об отсутствии;
              </li>
              <li>
                --date=%% аналогично и для даты. Но дата имеет формат yyyy-MM-dd, если дата указана неправильно, вывести текст ошибки
              </li>
              <li>
                --order-by=[title|author|date] отсортировать список книг по указанному полю, если указано неправильное поле, то вывести текст ошибки
              </li>
            </ul>
            Флаги могут использоваться одновременно, например: `get --author="Тютчев" --order-by="date"` - на выходе получаем список книг с автором "Тютчев", отсортированный по дате публикации
          </li>
          <li>
            buy = убирает одну книгу из списка отображаемых
            <br>
            Флаг:
            <ul type="circle">
              <li>
                --id=%% Id книги, которую нужно купить
              </li>
            </ul>
          </li>
        </ul>
      </li>
    </ul>
  </li>
</ol>

## Пример запуска сайта
![alt text](https://github.com/val-ugs/UDevMe.BookStore/blob/master/BlazorWebImage.PNG?raw=true)

## Пример запуска консольного режима
![alt text](https://github.com/val-ugs/UDevMe.BookStore/blob/master/ConsoleAppImage.PNG?raw=true)
