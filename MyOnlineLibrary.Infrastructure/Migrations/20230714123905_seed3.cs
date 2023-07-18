using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOnlineLibrary.Data.Migrations
{
    public partial class seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Description", "ImageUrl", "Rating" },
                values: new object[] { "Oli Hazzard", "Lorem Ipsum consists of a single, 60,000-word sentence. An epistolary fiction to an unidentified email recipient, the novel is modelled after the Japanese prose genre of the zuihitsu, an unfolding sentence in which resolution and closure are endlessly deferred. Our relationships with time and the environment have been radically altered by our awareness of global warming and the experience of being on the internet, and this shape-shifting novel is written out of and towards this moment of crisis in the ordinary, in which the experience of attention has changed entirely. Playful, disruptive and digressive, it reflects the associative movements of our minds. Lorem Ipsum is also an intimate, singular exploration of being a parent, a child, dreams, work, fantasies, happiness, memory, protest, repetition, intergenerational conflict, and the forms of community which appear or disappear based on how we conceive of 'shared time'. It is a book about the foundations upon which we build our lives: in John Ashbery’s words: ‘a chronicle of its own creation’.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1618913266i/57801373.jpg", 3.4m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Description", "ImageUrl", "Rating" },
                values: new object[] { "Dolor Sit", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b", 9.5m });
        }
    }
}
