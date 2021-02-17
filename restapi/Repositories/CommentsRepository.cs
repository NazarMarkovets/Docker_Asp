using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using restapi.Factories;
using restapi.Models;


namespace restapi.Repositories
{
    public class CommentsRepository
    {
        public void InsertComment(Comment comment)
        { 
            var commandText =
                $"insert into comments.comment values({comment.id}, '{comment.slur}' , '{comment.body}');";
            MySqlCommand sqlCommand = new MySqlCommand(commandText);
            ExecuteDataUpdatingTypeComment(sqlCommand);
        }

        public void DeleteComment(int id)
        {
            
            var commandText = $"DELETE FROM comments.comment where id = {id};";
            MySqlCommand cmd = new MySqlCommand(commandText);
            ExecuteDataUpdatingTypeComment(cmd);
        }

        private Dbfactory _factory = new Dbfactory();

        public List<Comment> FindCommentsById(int commentId)
        {
            var commentsList = new List<Comment>();
            var connection = _factory.GetConnection();
            try
            {
                connection.Open();
                string sqlQuery =
                    $"select id,slur,body from comments.comment where id = {commentId}";

                MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, connection);

                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        var comment = new Comment           
                        {
                            id = sqlDataReader.GetInt32(0),
                            slur = sqlDataReader.GetString(1),
                            body = sqlDataReader.GetString(2)
                        };
                        commentsList.Add(comment);
                    }
                }
            }
            catch
            {
                throw new DataException("Can not execute read request. Place: FindCommentsByArticleId");
            }
            finally
            {
                connection.Close();
            }
            return commentsList;
        }

        public void ExecuteDataUpdatingTypeComment(MySqlCommand command)
        {
            var connection = _factory.GetConnection();
            MySqlCommand executeCmd = command;
            executeCmd.Connection = connection;
            try
            {
                connection.Open();
                executeCmd.ExecuteNonQuery();
            }
            catch
            {
                throw new DataException($"Can not execute. Exception in ExecuteDataUpdatingTypeComment");
            }
            finally
            {
                connection.Close();
            }
        }
    }
    
}